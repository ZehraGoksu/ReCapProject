﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface ICustomerService
	{
		IDataResult<List<Customer>> GetAll();
		IDataResult<Customer> GetById(int Id);
		IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
		IResult Add(Customer customer);
		IResult Update(Customer customer);
		IResult Delete(Customer customer);

	}
}
