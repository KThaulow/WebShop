using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Users
{
	public class UserRepository : IUserRepository
	{
		private UserContext _context;

		public UserRepository(UserContext usercontext)
		{
			_context = usercontext;
		}

		public void CreateUser(User user)
		{
			_context.Add(user);
			_context.SaveChanges();
		}

		public void DeleteUser(int id)
		{
			var user = _context.Users.FirstOrDefault(e => e.Id == id);
			_context.Remove(user);
			_context.SaveChanges();
		}

		public void DeleteUser(User user)
		{
			_context.Remove(user);
			_context.SaveChanges();
		}

		public IEnumerable<User> ReadAllUsers()
		{
			return _context.Users;
		}

		public User ReadUser(int id)
		{
			return _context.Users.FirstOrDefault(t => t.Id == id);
		}

		public void UpdateUser(User user)
		{
			_context.Users.Update(user);
			_context.SaveChanges();
		}
	}
}
