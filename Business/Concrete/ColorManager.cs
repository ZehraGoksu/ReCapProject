using Business.Abstractor;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorService _colorDal = null;
		public ColorManager(IColorService colorService)
		{
			_colorDal = colorService;
		}
		public List<Color> GetAll()
		{
			return _colorDal.GetAll();
		}
	}
}
