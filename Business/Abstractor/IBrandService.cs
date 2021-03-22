using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface IBrandService
	{
        List<Brand> GetAll();
     
    }
}
