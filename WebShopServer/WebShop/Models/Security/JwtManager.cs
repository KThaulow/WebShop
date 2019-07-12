using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebShop.Models.Security
{
	public class JwtManager : IJwtManager
	{
		private string m_secret;

		public JwtManager(IConfiguration configuration)
		{
			m_secret = configuration["Token"];
		}

		public string GenerateToken(string username, int expireMinutes = 20)
		{
			var symmetricKey = Convert.FromBase64String(m_secret);
			var tokenHandler = new JwtSecurityTokenHandler();

			var now = DateTime.UtcNow;
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
						{
						new Claim(ClaimTypes.Name, username)
					}),

				Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
			};

			var stoken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(stoken);

			return token;
		}
	}
}
