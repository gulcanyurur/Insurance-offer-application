using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class InsuredManager : IInsuredService
    {
        private readonly IInsuredDal _insuredDal;

        public InsuredManager(IInsuredDal insuredDal)
        {
            _insuredDal = insuredDal;
        }

        public string Add(Insured insured)
        {
            _insuredDal.Add(insured);
            return "Müşteri bilgileri başarıyla eklenmiştir.";
        }


        public string Delete(Insured insured)
        {
            _insuredDal.Delete(insured);
            return "Müşteri bilgileri başarıyla silinmiştir.";
        }

        public List<Insured> GetAll()
        {
            return _insuredDal.GetList().ToList();
        }

        public Insured GetById(int insuredId)
        {
            return _insuredDal.Get(i => i.InsuredID == insuredId);
        }

        public string Update(Insured insured)
        {
            _insuredDal.Update(insured);
            return "Müşteri bilgileri başarıyla güncellenmiştir.";
        }

        public Insured GetByTCKN(string tckn)
        {
            return _insuredDal.Get(i => i.TCKN == tckn);
        }
    }
}







