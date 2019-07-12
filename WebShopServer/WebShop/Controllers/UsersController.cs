using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Models.Repositories;
using WebShop.Models.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShop.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private IRepositoryUnitOfWork m_repository;

		public UsersController(IRepositoryUnitOfWork repository)
		{
			m_repository = repository;
		}

		// GET: api/<controller>
		[HttpGet]
		public IEnumerable<User> Get()
		{
			return m_repository.User.FindAll();
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public User Get(int id)
		{
			return m_repository.User.FindByCondition(e => e.Id == id).FirstOrDefault();
		}

		// POST api/<controller>
		[HttpPost("authenticate")]
		public ActionResult<User> Authenticate([FromBody]dynamic login)
		{
			string username = login.username;
			string password = login.password;

			var user = m_repository.User.FindByCondition(e => e.Username == username && e.Password == password).FirstOrDefault();

			if (user != null)
			{
				return user;
			}

			return Unauthorized("Username or password is incorrect");
		}

		// PUT api/<controller>
		[HttpPut]
		public void Put([FromBody]User user)
		{
			m_repository.User.Create(user);
			m_repository.Save();
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			m_repository.User.Delete(id);
			m_repository.Save();
		}
	}
}
