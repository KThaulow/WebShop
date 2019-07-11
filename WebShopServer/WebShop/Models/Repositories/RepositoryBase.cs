using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected RepositoryContext RepositoryContext { get; set; }

		public RepositoryBase(RepositoryContext repositoryContext)
		{
			this.RepositoryContext = repositoryContext;
		}

		public IEnumerable<T> FindAll()
		{
			return this.RepositoryContext.Set<T>().AsNoTracking();
		}

		public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
		}

		public void Create(T entity)
		{
			this.RepositoryContext.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			this.RepositoryContext.Set<T>().Update(entity);
		}

		public void Delete(T entity)
		{
			this.RepositoryContext.Set<T>().Remove(entity);
		}

		public T FindById(int id)
		{
			return this.RepositoryContext.Set<T>().Find(id);
		}

		public void Delete(int id)
		{
			T entityToDelete = this.RepositoryContext.Set<T>().Find(id);
			Delete(entityToDelete);
		}
	}
}
