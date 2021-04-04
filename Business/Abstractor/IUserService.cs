using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface IUserService:ICRUDService<User>
	{
       List<OperationClaim> GetClaims(User user);
       User GetByMail(string email);
       

    }
}
