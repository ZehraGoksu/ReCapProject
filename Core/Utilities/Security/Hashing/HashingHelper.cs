using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
	public class HashingHelper
	{
		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{// bir password vericez ve dışarıya şu iki değeri çıkarıcak bir yapı yapıcaz hash ve salt

			using (var hmac = new System.Security.Cryptography.HMACSHA512())//kriptografi sınıfındaki 512 algoritmasını kullanıyoruz.
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//byte array olarak göndermiş olduk passwordu
			}

		}
		public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//passwordhashi doğrula diyoruz out a gerek yok bu değerleir biz vericez
		{                                                                                               //yani kişinin girdiği veritabanına kayıtlı olan şifresini giriyor ve onu doğrulayacağız

			using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//saltıkullanması gerktiğini zaten yukarda söyledik
				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != passwordHash[i])
					{
						return false;
					}

				}
				return true;
			}
		}
	}
}
