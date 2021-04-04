using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
	public class SecurityKeyHelper //işin içinde şifreleme olan sistemlerde bir byte array formatında oluşturmamız gerekiyor. asp.net in anlayacağı hale
	{
		public static SecurityKey CreateSecurityKey(string securityKey)
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//simetrik bir security key kullanacağız
		}
	}
}
