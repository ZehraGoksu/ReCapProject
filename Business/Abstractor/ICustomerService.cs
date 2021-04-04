﻿using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface ICustomerService:ICRUDService<Customer>
	{
		IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
		
	}
}
