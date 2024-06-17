using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTravelDetailDal : EfEntityRepositoryBase<TravelDetail, EurekoDatabase>, ITravelDetailDal
    {
    }
}
