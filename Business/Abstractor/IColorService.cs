using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface IColorService
	{
		List<Color> GetAll();
	}
}
