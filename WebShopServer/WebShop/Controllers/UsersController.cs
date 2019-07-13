﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Models.Repositories;
using WebShop.Models.Security;
using WebShop.Models.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShop.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private IRepositoryUnitOfWork m_repository;
		private IJwtManager m_jwtManager;

		public UsersController(IRepositoryUnitOfWork repository, IJwtManager jwtManager)
		{
			m_repository = repository;
			m_jwtManager = jwtManager;
		}

		[HttpGet]
		public IEnumerable<User> Get()
		{
			return m_repository.User.FindAll();
		}

		[HttpGet("{id}")]
		public User Get(int id)
		{
			return m_repository.User.FindByCondition(e => e.Id == id).FirstOrDefault();
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public ActionResult<User> Authenticate([FromBody]dynamic login) // TODO: create login class
		{
			string username = login.username;
			string password = login.password;

			var user = m_repository.User.FindByCondition(e => e.Username == username && e.Password == password).FirstOrDefault();

			if (user != null)
			{
				var token = m_jwtManager.GenerateToken(user.Username);
				user.Token = token;
				return user;
			}

			return Unauthorized("Username or password is incorrect");
		}

		[AllowAnonymous]
		[HttpPut]
		public void Put([FromBody]User user)
		{
			m_repository.User.Create(user);
			m_repository.Save();
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			m_repository.User.Delete(id);
			m_repository.Save();
		}
	}
}
