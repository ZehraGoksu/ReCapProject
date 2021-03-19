using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface ICarService
	{
		List<Car> GetAll();
	}
}
