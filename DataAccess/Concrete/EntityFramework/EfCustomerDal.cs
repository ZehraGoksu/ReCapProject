using Core.DataAccess.EntityFramework;
using DataAccess.Abstractor;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarContext>, ICustomerDal
	{
		public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
		{
			using (CarContext context = new CarContext())
			{
				var result = from c in filter is null ? context.Customers : context.Customers.Where(filter)
							 join u in context.Users on c.UserId equals u.UserId
							 select new CustomerDetailDto { CompanyName = c.CompanyName, CustomerId = c.CustomerId, 
								                            UserId = u.UserId, UserLastName = u.LastName, UserName = u.FirstName};
				return result.ToList();
			}
		}
	}
}
