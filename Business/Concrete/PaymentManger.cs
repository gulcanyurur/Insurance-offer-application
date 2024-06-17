using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public Payment Get(Expression<Func<Payment, bool>> filter)
        {
            var payment = _paymentDal.Get(filter);
            if (payment != null)
            {
                payment.MaskedCardNumber = MaskCardNumber(payment.MaskedCardNumber);
                payment.MaskedCVV = MaskCVV(payment.MaskedCVV);
            }
            return payment;
        }

        public IList<Payment> GetList(Expression<Func<Payment, bool>> filter = null)
        {
            var payments = _paymentDal.GetList(filter);
            foreach (var payment in payments)
            {
                payment.MaskedCardNumber = MaskCardNumber(payment.MaskedCardNumber);
                payment.MaskedCVV = MaskCVV(payment.MaskedCVV);
            }
            return payments;
        }

        public void Add(Payment payment)
        {
            payment.MaskedCardNumber = MaskCardNumber(payment.MaskedCardNumber);
            payment.MaskedCVV = MaskCVV(payment.MaskedCVV);

            _paymentDal.Add(payment);
        }

        private string MaskCardNumber(string cardNumber)
        {
            
            if (cardNumber.Length < 10)
                return cardNumber; 

            int lengthToMask = cardNumber.Length - 10;
            return cardNumber.Substring(0, 6) + new string('*', lengthToMask) + cardNumber.Substring(cardNumber.Length - 4);
        }

        private string MaskCVV(string cvv)
        {
           
            return new string('*', cvv.Length);
        }
    }
}

