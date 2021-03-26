﻿using Business.Abstractor;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;
		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}
		[Core.Aspects.Autofac.Validation.ValidationAspect(typeof(ColorValidator))]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.Added);
		}

		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.Deleted);
		}

		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
		}

		public IDataResult<Customer> GetById(int Id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == Id));
		}

		public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
		{
			return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
		}

		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.Updated);
		}
	}
}
