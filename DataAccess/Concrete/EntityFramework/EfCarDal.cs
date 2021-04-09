using Core.DataAccess.EntityFramework;
using DataAccess.Abstractor;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			using (CarContext context = new CarContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands on c.BrandId equals b.BrandId
							 join co in context.Colors on c.ColorId equals co.ColorId
							 select new CarDetailDto {CarId=c.Id  ,CarName = c.CarName ,ColorName = co.ColorName, 
								                      BrandName = b.BrandName, Description = c.Description, ModelYear = c.ModelYear.ToString(), 
								                      DailyPrice = c.DailyPrice, BrandId = b.BrandId, ColorId = co.ColorId, 
								                      ImagePath = (from ci in context.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()
							 };
				return filter == null ? result.ToList() : result.Where(filter).ToList();		 
			};
		}
	}
}