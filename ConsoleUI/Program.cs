using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			Car car = new Car { BrandId = 5, ModelYear = 2020, DailyPrice = 210, Description = "Otomatik vites, benzinli", CarName = "Clio", ColorId = 5};

			carManager.Add(car);

			
		}
	}
}
