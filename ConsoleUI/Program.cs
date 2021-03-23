﻿using Business.Concrete;
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
			CarTest();
			ColorTest();
			BrandTest();

		}

		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			//Car car = new Car { BrandId = 13, ModelYear = 2020, DailyPrice = 210, Description = "Otomatik vites, benzinli", CarName = "Clio", ColorId = 5 };
			//Car car2 = new Car { BrandId = 1, ModelYear = 2021, DailyPrice = 320, Description = "AUDİ A5 2000 DİZEL", CarName = "A5", ColorId = 2 };
			//carManager.Add(car);
			//carManager.Add(car2);
			//carManager.Delete(new Car {Id = 13 });
			//Console.WriteLine(carManager.GetCarsByBrandId(2));

			//foreach (var cars in carManager.GetAll().Data)
			//{
			//	Console.WriteLine("Araç Bilgileri: " + cars.CarName + "  " + cars.Description + "  " + cars.DailyPrice + " tl'dir.");
			//}
			foreach (var cars in carManager.GetCarDetails().Data) 
			{
				Console.WriteLine(cars.BrandName + " " + cars.CarName + " --- " + cars.ColorName);
			}
			
			
		}
		private static void BrandTest()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			//Brand brand = new Brand { BrandName = "Volvo" };
			//brandManager.Add(brand);
			//brandManager.Delete(new Brand { BrandId = 17 });
			//Console.WriteLine(brandManager.GetById(2));

			foreach (var brands in brandManager.GetAll().Data)
			{
				Console.WriteLine("Araç Markaları: " + brands.BrandName );
			}


		}
		private static void ColorTest()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			//Color color = new Color { ColorName = "Sarı"};
			//colorManager.Add(color);
			//colorManager.Delete(new Color { ColorId = 5 });
			//Console.WriteLine(colorManager.GetById(4));

			foreach (var colors in colorManager.GetAll().Data)
			{
				Console.WriteLine("Araç Renkleri: " + colors.ColorName);
			}


		}


	}
}
