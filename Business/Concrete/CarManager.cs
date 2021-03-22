﻿using Business.Abstractor;
using DataAccess.Abstractor;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public void Add(Car car)
		{
			//Araba ismi minimum 2 karakter olmalıdır

			//Araba günlük fiyatı 0'dan büyük olmalıdır.
			if(car.CarName.Length < 2)
			{
				Console.WriteLine("Araç adı en az 2 karakterden oluşmalıdır.");
				
			}
			else if(car.DailyPrice <= 0)
			{
				Console.WriteLine("Araç günlük fiyatı 0'dan büyük olmalıdır.");
			}
			else
			{
				_carDal.Add(car);
				Console.WriteLine(car.CarName + " başarılı bir şekilde kaydedildi.");
			}
		}


		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

		public List<Car> GetCarsByBrandId(int id)
		{
			return _carDal.GetAll(c => c.BrandId == id);
		}

		public List<Car> GetCarsByColorId(int id)
		{
			return _carDal.GetAll(c => c.ColorId == id);
		}

		
	}
}