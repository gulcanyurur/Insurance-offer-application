using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICoverageService
    {
        Coverage GetById(int coverageId);
        List<Coverage> GetAll();
        string Add(Coverage coverage);
        string Update(Coverage coverage);
        void Delete(Coverage coverage);
    }
}

