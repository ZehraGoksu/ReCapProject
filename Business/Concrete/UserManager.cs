using Business.Abstractor;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
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


        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(r => r.Id == Id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);

        }

        [SecuredOperation("admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(user.Id + Messages.Deleted);
        }

        [SecuredOperation("admin")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(user.Id + Messages.Updated);
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
		{
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
		{
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
	}
}
