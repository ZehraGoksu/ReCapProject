using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface ICarService:ICRUDService<Car>
	{
		IDataResult<List<Car>> GetCarsByBrandId(int id);
		IDataResult<List<Car>> GetCarsByColorId(int id);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IResult AddTransactionalTest(Car car);
		IDataResult<List<CarDetailDto>> GetCarByCarId(int id);
		IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int id);
		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id);
	}
}
