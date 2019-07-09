using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Users;

namespace WebShop.Models.Users
{
	public interface IUserRepository
	{
		void CreateUser(User user);
		IEnumerable<User> ReadAllUsers();
		User ReadUser(int id);
		void UpdateUser(User user);
		void DeleteUser(int id);
		void DeleteUser(User user);
	}
}
