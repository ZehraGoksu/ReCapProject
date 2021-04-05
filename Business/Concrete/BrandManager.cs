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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		[ValidationAspect(typeof(BrandValidator))]
		[SecuredOperation("admin")]
		[CacheRemoveAspect("IBrandService.Get")]
		public IResult Add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Messages.Added);
		}

		[SecuredOperation("admin")]
		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult(Messages.Deleted);
			
		}

		[CacheAspect]
		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
		}

		[CacheAspect]
		public IDataResult<Brand> GetById(int brandId)
		{
			return new SuccessDataResult<Brand> (_brandDal.Get(b => b.BrandId == brandId));
			
		}

		[SecuredOperation("admin")]
		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult(Messages.Updated);
		}
	}
}
