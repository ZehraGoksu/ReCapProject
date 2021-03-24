﻿using Business.Abstractor;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstractor;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

		public IResult Add(Rental rental)
		{
			if (rental.CarId <= 0 )
			{
				Console.WriteLine(Messages.AddedErrorCarId);
			}
			_rentalDal.Add(rental);
			return new SuccessResult(Messages.Added);

		}

		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(rental.Id + Messages.Deleted);
		}

		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
		}

		public IDataResult<Rental> GetById(int Id)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
		}

		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(rental.Id + Messages.Updated);
		}
	}
}