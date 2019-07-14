using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Users;

namespace WebShop.Models.Identity
{
	public class IdentityContext : IdentityDbContext<ApplicationUser>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options)
			: base(options)
		{
		}

		//protected override void OnConfiguring
		//	(DbContextOptionsBuilder optionsBuilder) =>
		//		optionsBuilder.UseSqlite("your connection string");
	}
}
