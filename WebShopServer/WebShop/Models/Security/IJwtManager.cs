using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Security
{
	public interface IJwtManager
	{
		string GenerateToken(string username, int expireMinutes = 20);
	}
}
