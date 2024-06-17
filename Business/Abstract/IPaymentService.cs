
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        Payment Get(Expression<Func<Payment, bool>> filter);
        IList<Payment> GetList(Expression<Func<Payment, bool>> filter = null);
        void Add(Payment payment);
        
    }
}
