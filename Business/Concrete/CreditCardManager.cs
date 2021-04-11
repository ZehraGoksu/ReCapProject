using Business.Abstractor;
using Core.Utilities.Results;
using DataAccess.Abstractor;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CreditCardManager:ICreditCardService
	{
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard card)
        {
            _creditCardDal.Add(card);
            return new SuccessResult("Ödeme işlemi başarılı bir şekilde gerçekleştirildi.");
        }

        public IResult Delete(CreditCard card)
        {
            _creditCardDal.Delete(card);
            return new SuccessResult("Kart bilgileriniz silindi.");

        }
        public IResult MakePayment(CreditCard card)
        {
            int random = new Random().Next(0, 2);
            if (random == 0)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }

        public IResult Update(CreditCard card)
        {
            _creditCardDal.Update(card);
            return new SuccessResult("Kartınız güncellendi.");

        }
    }

}
