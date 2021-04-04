using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstractor
{
	public interface IUserDal :IEntityRepository<User>
	{
		List<OperationClaim> GetClaims(User user);
	}
}
