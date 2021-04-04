using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
	public class SigningCredentialsHelper
	{
		public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) //json web tokenlarının oluşturulabilmesi için anahtarımızı veriyoruz parametre
		{
			return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);// bir tane şifreleme işlemi yapacaksın anahtar olaarak bu anahtarı kullan ve
																							   //şifreleme olarak da güvenlik algoritmalaeından hmacsha kullanıcaz demek.
		}                                                                                      //hasleme ve doğrulamada zaten belirttik hmac diye ama bu sisteme asp.netin ihtiyacı olanı verdik burda hangi anahtar hangi algoritma yani
	}
}
