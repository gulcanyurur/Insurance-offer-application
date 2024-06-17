using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ITravelDetailService
    {
        TravelDetail Get(Expression<Func<TravelDetail, bool>> filter);
        IList<TravelDetail> GetList(Expression<Func<TravelDetail, bool>> filter = null);
        void Add(TravelDetail travelDetail);
    }
}
