using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface IRentalService:ICRUDService<Rental>
	{
		IDataResult<List<RentalDetailDto>> GetRentalDetails();
	}
}
