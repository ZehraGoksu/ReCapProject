using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
	public class AccessToken //erişim anahtarı
	{
		//anlamsız karakterlerden oluşan anahtar değeri
		public string Token { get; set; }
		public DateTime Expiration { get; set; } //geçerli olduğu son süre bitiş tarihini verir
	}
}
