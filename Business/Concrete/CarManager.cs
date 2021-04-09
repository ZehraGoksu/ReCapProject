using Business.Abstractor;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

		[SecuredOperation("admin, car.add")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
				return new SuccessResult(car.CarName + Messages.Added);
		
		}

		[TransactionScopeAspect]
		public IResult AddTransactionalTest(Car car)
		{
			_carDal.Update(car);
			_carDal.Add(car);
			return new SuccessResult(Messages.Updated);
		}

		[SecuredOperation("admin")]
		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(car.CarName + Messages.Deleted);

		}

		[CacheAspect(duration: 10)]
		[PerformanceAspect(3)]
		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
		}

		[CacheAspect]
		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == carId));
		}

		public IDataResult<List<CarDetailDto>> GetCarByCarId(int id)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id));
		}

		[CacheAspect]
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

		public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int id)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int carId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == carId));
		}

		[SecuredOperation("admin, car.add")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.Updated);
		}
	}
}
