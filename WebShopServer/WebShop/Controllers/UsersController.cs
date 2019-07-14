using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Models.Identity;
using WebShop.Models.Repositories;
using WebShop.Models.Security;
using WebShop.Models.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShop.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private IJwtManager m_jwtManager;
		private UserManager<ApplicationUser> m_userManager = null;
		private SignInManager<ApplicationUser> m_signInManager = null;

		public UsersController(IJwtManager jwtManager,
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			m_jwtManager = jwtManager;
			m_userManager = userManager;
			m_signInManager = signInManager;
		}

		[HttpGet]
		public IEnumerable<ApplicationUser> Get()
		{
			return m_userManager.Users;
		}

		[HttpGet("{id}")]
		public ApplicationUser Get(string id)
		{
			return m_userManager.FindByIdAsync(id).GetAwaiter().GetResult();
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public ActionResult<ClientUser> Authenticate([FromBody]Login login)
		{
			var user = m_userManager.FindByNameAsync(login.Username).GetAwaiter().GetResult();
			var result = m_signInManager.CheckPasswordSignInAsync(user, login.Password, false).GetAwaiter().GetResult();

			if (result.Succeeded)
			{
				var token = m_jwtManager.GenerateToken(user.UserName);
				return new ClientUser() { FirstName = user.FirstName, LastName = user.LastName, Username = user.UserName, Token = token };
			}

			return Unauthorized("Username or password is incorrect");
		}

		[AllowAnonymous]
		[HttpPut]
		public IActionResult Put([FromBody]NewUser user)
		{
			var applicationUser = new ApplicationUser()
			{
				UserName = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName
			};

			var result = m_userManager.CreateAsync(applicationUser, user.Password).GetAwaiter().GetResult();

			if (result.Succeeded)
			{
				return Ok();
			}

			return ValidationProblem();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			var user = m_userManager.FindByIdAsync(id).GetAwaiter().GetResult();
			var result = m_userManager.DeleteAsync(user).GetAwaiter().GetResult();

			if (result.Succeeded)
			{
				return Ok();
			}

			return ValidationProblem();
		}
	}
}
