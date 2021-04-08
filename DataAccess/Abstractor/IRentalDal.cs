using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstractor
{
	public interface IRentalDal:IEntityRepository<Rental>
	{
		List<RentalDetailDto> GetRentalDetails();
	}
}
