using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Users
{
	public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
	{

		public UserRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}
