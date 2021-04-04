using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
	public interface ITokenHelper
	{
		AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
		//operationClaim den gelen hangi yetkiler koyacağımız
		//giriş bilgileri doğruysa bu çalışır ilgili kullanıcı için veritabanına gider, kullanıcının claimlerini bulup 
		// bir tane json web token üretip onları sisteme vericek 

	}
}
