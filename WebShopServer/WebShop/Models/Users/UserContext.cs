using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Users
{
	public class UserContext : DbContext, IUserContext
	{
		private string _username;
		private string _password;

		public UserContext(DbContextOptions<UserContext> options, IConfiguration configuration)
			: base(options)
		{
			_username = configuration["Users:Username"];
			_password = configuration["Users:Password"];
		}

		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql($"Host=localhost;Database=WebShop;Username={_username};Password={_password}");
	}
}
