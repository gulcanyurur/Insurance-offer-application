using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class PolicyCoverageManager : IPolicyCoverageService
    {
        private readonly IPolicyCoverageDal _policyCoverageDal;

        public PolicyCoverageManager(IPolicyCoverageDal policyCoverageDal)
        {
            _policyCoverageDal = policyCoverageDal;
        }

        public string Add(PolicyCoverage policyCoverage)
        {
            _policyCoverageDal.Add(policyCoverage);
            return "Poliçe teminatı başarıyla kaydedildi.";
        }

        public void Delete(PolicyCoverage policyCoverage)
        {
            _policyCoverageDal.Delete(policyCoverage);
        }

        public List<PolicyCoverage> GetAll()
        {
            return _policyCoverageDal.GetList().ToList();
        }

        public PolicyCoverage GetById(int policyCoverageId)
        {
            return _policyCoverageDal.Get(p => p.PolicyCoverageID == policyCoverageId);
        }

        public string Update(PolicyCoverage policyCoverage)
        {
            _policyCoverageDal.Update(policyCoverage);
            return "Poliçe teminatı başarıyla güncellendi.";
        }
    }
}
