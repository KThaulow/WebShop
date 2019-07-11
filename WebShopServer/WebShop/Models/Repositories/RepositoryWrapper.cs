using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Users;

namespace WebShop.Models.Repositories
{
	public class RepositoryUnitOfWork : IRepositoryUnitOfWork
	{
		private RepositoryContext m_repoContext;
		private IUserRepository m_user;

		public RepositoryUnitOfWork(RepositoryContext repositoryContext)
		{
			m_repoContext = repositoryContext;
		}

		public IUserRepository User
		{
			get
			{
				if (m_user == null)
				{
					m_user = new UserRepository(m_repoContext);
				}

				return m_user;
			}
		}

		public void Save()
		{
			m_repoContext.SaveChanges();
		}
	}
}
