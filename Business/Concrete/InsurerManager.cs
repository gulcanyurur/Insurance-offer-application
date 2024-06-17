using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class InsurerManager : IInsurerService
    {
        private readonly IInsurerDal _insurerDal;

        public InsurerManager(IInsurerDal insurerDal)
        {
            _insurerDal = insurerDal;
        }

        public string Add(Insurer insurer)
        {
            _insurerDal.Add(insurer);
            return "Müşteri bilgileri başarıyla eklenmiştir.";
        }

        public string Delete(Insurer insurer)
        {
            _insurerDal.Delete(insurer);
            return "Müşteri bilgileri başarıyla silinmiştir.";
        }

        public List<Insurer> GetAll()
        {
            return _insurerDal.GetList().ToList();
        }

        public Insurer GetById(int insurerId)
        {
            return _insurerDal.Get(i => i.InsurerID == insurerId);
        }

        public string Update(Insurer insurer)
        {
            _insurerDal.Update(insurer);
            return "Müşteri bilgileri başarıyla güncellenmiştir.";
        }

        public Insurer GetByTCKN(string tckn)
        {
            return _insurerDal.Get(i => i.TCKN == tckn);
        }
    }
}




