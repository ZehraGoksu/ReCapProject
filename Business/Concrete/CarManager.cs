using Business.Abstractor;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstractor;
using Entities.Concrete;
using Entities.DTOs;
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

		public IResult Add(Car car)
		{
			//Araba ismi minimum 2 karakter olmalıdır

			//Araba günlük fiyatı 0'dan büyük olmalıdır.
			if(car.CarName.Length < 2)
			{
				return new SuccessResult(Messages.AddedErrorCarName);
				
			}
			else if(car.DailyPrice <= 0)
			{
				return new SuccessResult(Messages.AddedErrorDaily);
			}
			else
			{
				_carDal.Add(car);
				return new SuccessResult(car.CarName + Messages.Added);
			}
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(car.CarName + Messages.Deleted);

		}

		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
		}

		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == carId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
		}

		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.Updated);
		}
	}
}
