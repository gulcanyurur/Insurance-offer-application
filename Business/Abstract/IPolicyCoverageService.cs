using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPolicyCoverageService
    {
        PolicyCoverage GetById(int policyCoverageId);
        List<PolicyCoverage> GetAll();
        string Add(PolicyCoverage policyCoverage);
        string Update(PolicyCoverage policyCoverage);
        void Delete(PolicyCoverage policyCoverage);
    }
}
