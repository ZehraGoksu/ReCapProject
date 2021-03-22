using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface ICarService
	{
		List<Car> GetAll();
		List<Car> GetCarsByBrandId(int id);
		List<Car> GetCarsByColorId(int id);
		void Add(Car car);
	
	}
}
