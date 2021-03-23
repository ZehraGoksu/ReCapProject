using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface IColorService
	{
		void Add(Color color);
		List<Color> GetAll();
		Color GetById(int id);
		void Update(Color color);
		void Delete(Color color);
	}
}
