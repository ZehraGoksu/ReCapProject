using Business.Abstractor;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstractor;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;
		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		[ValidationAspect(typeof(UserValidator))]
		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(user.FirstName + Messages.Added);
		}

		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(user.FirstName + Messages.Deleted);
		}

		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
		}

		public IDataResult<User> GetById(int Id)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == Id));
		}

		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult(user.FirstName + Messages.Updated);
		}
	}
}
