using Business.Abstractor;
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

		public void Add(Brand brand)
		{
			_brandDal.Add(brand);
			Console.WriteLine(brand.BrandName + " başarılı bir şekilde kaydedildi.");
		}

		public void Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			Console.WriteLine(brand.BrandName + " başarılı bir şekilde silindi.");
		}

		public List<Brand> GetAll()
		{
			return _brandDal.GetAll();
		}


		public Brand GetById(int brandId)
		{
			return _brandDal.Get(b => b.BrandId == brandId);
			
		}

		public void Update(Brand brand)
		{
			_brandDal.Update(brand);
			Console.WriteLine(brand.BrandName + " başarılı bir şekilde güncellendi.");
		}
	}
}
