﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractor
{
	public interface IUserService
	{
		IDataResult<List<User>> GetAll();
		IDataResult<User> GetById(int Id);
		IResult Add(User user);
		IResult Update(User user);
		IResult Delete(User user);
	}
}