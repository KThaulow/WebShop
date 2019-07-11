using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Users;

namespace WebShop.Models.Repositories
{
	public interface IRepositoryUnitOfWork
	{
		IUserRepository User { get; }
		void Save();
	}
}
