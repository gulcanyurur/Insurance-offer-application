using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPolicyCoverageDal : EfEntityRepositoryBase<PolicyCoverage, EurekoDatabase>, IPolicyCoverageDal
    {
    }
}
