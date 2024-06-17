using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IInsuredService
    {
        Insured GetById(int insuredId);
        List<Insured> GetAll();
        string Add(Insured insured);
        string Update(Insured insured);
        string Delete(Insured insured);
        Insured GetByTCKN(string tckn);
    }
}

