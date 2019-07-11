using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public interface IRepositoryBase<T>
	{
		IEnumerable<T> FindAll();
		IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
		T FindById(int id);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(int id);
	}
}
