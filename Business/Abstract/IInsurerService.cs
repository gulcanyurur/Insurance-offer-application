using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IInsurerService
    {
        Insurer GetById(int insurerId);
        List<Insurer> GetAll();
        string Add(Insurer insurer);
        string Update(Insurer insurer);
        string Delete(Insurer insurer);
        Insurer GetByTCKN(string tckn);
    }
}

