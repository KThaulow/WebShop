using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Users
{
	public interface IUserContext
	{
		DbSet<User> Users { get; set; }
	}
}
