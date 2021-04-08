using Core.DataAccess.EntityFramework;
using DataAccess.Abstractor;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal:EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails()
		{
			using (CarContext context = new CarContext())
			{
				var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ct in context.Customers
                              on r.CustomerId equals ct.CustomerId
                             join u in context.Users
                             on ct.UserId equals u.Id
                             select new RentalDetailDto{ Id = r.Id,BrandName = b.BrandName,FirstName = u.FirstName,LastName = u.LastName,RentDate = r.RentDate,ReturnDate = r.ReturnDate };
                return result.ToList();
            };
		}
	}
}
