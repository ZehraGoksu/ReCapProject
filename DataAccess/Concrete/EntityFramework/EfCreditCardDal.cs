using Core.DataAccess.EntityFramework;
using DataAccess.Abstractor;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, CarContext>, ICreditCardDal
	{
	}

}
