using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class TravelDetailManager : ITravelDetailService
    {
        private readonly ITravelDetailDal _travelDetailDal;

        public TravelDetailManager(ITravelDetailDal travelDetailDal)
        {
            _travelDetailDal = travelDetailDal;
        }

        public TravelDetail Get(Expression<Func<TravelDetail, bool>> filter)
        {
            return _travelDetailDal.Get(filter);
        }

        public IList<TravelDetail> GetList(Expression<Func<TravelDetail, bool>> filter = null)
        {
            return _travelDetailDal.GetList(filter);
        }

        public void Add(TravelDetail travelDetail)
        {
            _travelDetailDal.Add(travelDetail);
        }
    }
}
