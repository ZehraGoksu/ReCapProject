using DataAccess.Abstractor;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
		public InMemoryCarDal()
		{
			_cars = new List<Car> {
			new Car{Id=1, BrandId=1, ColorId=3, ModelYear=2015, DailyPrice=180, Description="Opel Corsa 1.2 Benzinli Manuel" },
			new Car{Id=2, BrandId=3, ColorId=6, ModelYear=2020, DailyPrice=200, Description="Citroen C3 1.2 Benzinli Otomatik " },
			new Car{Id=3, BrandId=4, ColorId=1, ModelYear=2017, DailyPrice=240, Description="Hyundai Accent Blue1.6 Dizel Otomatik" },
			new Car{Id=4, BrandId=3, ColorId=1, ModelYear=2013, DailyPrice=190, Description="Citroen C-elysee 1.6 Dizel " },
			};

		}
		
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car deleteCar = _cars.SingleOrDefault(c=> c.Id == car.Id);
			_cars.Remove(deleteCar);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetById(int Id)
		{
			return _cars.Where(c=>c.Id == Id).ToList();
		}

		public void Update(Car car)
		{
			Car updateCar = _cars.SingleOrDefault(c=> c.Id == car.Id);
			updateCar.BrandId = car.BrandId;
			updateCar.ColorId = car.ColorId;
			updateCar.ModelYear = car.ModelYear;
			updateCar.DailyPrice = car.DailyPrice;
			updateCar.Description = car.Description;
		}
	}
}
