using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstractor;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal: EfEntityRepositoryBase<User, CarContext>, IUserDal
	{
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
                //operationClaimlerle userOperationClaimlere join atıyor içerisinde id si bizim gönderdiğimiz user a eşit id yi buluyor operationClaim olarak return ediyoruz

            }
        }
    }
}
