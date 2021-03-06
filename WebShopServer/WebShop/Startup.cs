﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebShop.Models;
using WebShop.Models.Identity;
using WebShop.Models.Repositories;
using WebShop.Models.Security;
using WebShop.Models.Users;

namespace WebShop
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add authentication by default to controllers
			ConfigureAuthentication(services);

			// Configure CORS
			ConfigureCORS(services);

			// Configure DI
			ConfigureDI(services);

			// Configure identity
			ConfigureIdentity(services);

			// Configure JWT authentication
			ConfigureJWTAuthentication(services);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IdentityContext dbContext)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseAuthentication();
			app.UseCors("MyPolicy");
			app.UseHttpsRedirection();
			app.UseMvc();

			// Create tables
			dbContext.Database.EnsureCreated();
		}

		private void ConfigureDI(IServiceCollection services)
		{
			services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
			services.AddScoped<IJwtManager, JwtManager>();
			services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
		}

		private static void ConfigureAuthentication(IServiceCollection services)
		{
			services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder()
								 .RequireAuthenticatedUser()
								 .Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		private static void ConfigureCORS(IServiceCollection services)
		{
			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));
		}

		private void ConfigureJWTAuthentication(IServiceCollection services)
		{
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims

			var secret = Configuration["Secret"];
			var key = Convert.FromBase64String(secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
		}




		private void ConfigureIdentity(IServiceCollection services)
		{
			services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

			services.Configure<IdentityOptions>(options =>
			{
				// Default Password settings.
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;
			});
		}


		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((context, config) =>
				{
					// TODO: Create certificate for Azure Key Vault (https://docs.microsoft.com/en-us/aspnet/core/security/key-vault-configuration?view=aspnetcore-2.2)
					if (context.HostingEnvironment.IsProduction())
					{
						var builtConfig = config.Build();

						using (var store = new X509Store(StoreName.My,
							StoreLocation.CurrentUser))
						{
							store.Open(OpenFlags.ReadOnly);
							var certs = store.Certificates
								.Find(X509FindType.FindByThumbprint,
									builtConfig["AzureADCertThumbprint"], false);

							config.AddAzureKeyVault(
								$"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
								builtConfig["AzureADApplicationId"],
								certs.OfType<X509Certificate2>().Single());

							store.Close();
						}
					}
					// Uses secrets.json in develop mode by default
				})
				.UseStartup<Startup>();
	}
}
