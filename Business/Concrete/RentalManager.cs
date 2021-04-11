using Business.Abstractor;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstractor;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}

		[ValidationAspect(typeof(RentalValidator))]
		[SecuredOperation("admin")]
		public IResult Add(Rental rental)
		{
			var cardata1 = _rentalDal.GetAll(p => p.CarId == rental.CarId).Last();
			var cardataDate = _rentalDal.GetAll(p => p.RentDate == rental.RentDate);
			var cardataDate2 = _rentalDal.GetAll(p => p.ReturnDate == rental.ReturnDate);

			if (cardata1.ReturnDate != null && cardata1.RentDate < rental.RentDate && cardata1.ReturnDate < rental.ReturnDate)
			{
				_rentalDal.Add(rental);
				return new SuccessResult();
			}
			return new ErrorResult(Messages.CarRentalError);

		}

		[SecuredOperation("admin")]
		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(rental.Id + Messages.Deleted);
		}

		[CacheAspect]
		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
		}

		[CacheAspect]
		public IDataResult<Rental> GetById(int Id)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
		}

		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
		}

		[SecuredOperation("admin")]
		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(rental.Id + Messages.Updated);
		}
	}
}
