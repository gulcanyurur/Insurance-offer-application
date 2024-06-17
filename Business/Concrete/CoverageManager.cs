using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CoverageManager : ICoverageService
    {
        private readonly ICoverageDal _coverageDal;

        public CoverageManager(ICoverageDal coverageDal)
        {
            _coverageDal = coverageDal;
        }

        public string Add(Coverage coverage)
        {
            _coverageDal.Add(coverage);
            return "Teminat başarıyla kaydedildi.";
        }

        public void Delete(Coverage coverage)
        {
            _coverageDal.Delete(coverage);
        }

        public List<Coverage> GetAll()
        {
            return _coverageDal.GetList().ToList();
        }

        public Coverage GetById(int coverageId)
        {
            return _coverageDal.Get(c => c.CoverageID == coverageId);
        }

        public string Update(Coverage coverage)
        {
            _coverageDal.Update(coverage);
            return "Teminat başarıyla güncellendi.";
        }
    }
}

