using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstractor
{
	public interface ICarDal:IEntityRepository<Car>
	{
		List<CarDetailDto> GetCarDetails();

	}
}
