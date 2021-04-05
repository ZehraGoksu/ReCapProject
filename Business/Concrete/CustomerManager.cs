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
		[ValidationAspect(typeof(ColorValidator))]
		[SecuredOperation("admin")]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.Added);
		}

		[SecuredOperation("admin")]
		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.Deleted);
		}

		[CacheAspect]
		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
		}

		[CacheAspect]
		public IDataResult<Customer> GetById(int Id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == Id));
		}

		public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
		{
			return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
		}

		[SecuredOperation("admin")]
		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.Updated);
		}
	}
}
