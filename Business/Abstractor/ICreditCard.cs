using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface ICreditCard
	{
		IResult Add(CreditCard entity);
		IResult Delete(CreditCard entity);
		IResult Update(CreditCard entity);

		IDataResult<List<CreditCard>> GetByCustomerId(int customerId);
	}
}
