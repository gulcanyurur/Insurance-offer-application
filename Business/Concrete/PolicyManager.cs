using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class PolicyManager : IPolicyService
    {
        private readonly IPolicyDal _policyDal;

        public PolicyManager(IPolicyDal policyDal)
        {
            _policyDal = policyDal;
        }

        public string Add(Policy policy)
        {
            _policyDal.Add(policy);
            return "Poliçe başarıyla kaydedildi.";
        }

        public void Delete(Policy policy)
        {
            _policyDal.Delete(policy);
        }

        public List<Policy> GetAll()
        {
            return _policyDal.GetList().ToList();
        }

        public Policy GetById(int policyId)
        {
            return _policyDal.Get(p => p.PolicyID == policyId);
        }

        public string Update(Policy policy)
        {
            _policyDal.Update(policy);
            return "Poliçe başarıyla güncellendi.";
        }

        public bool PolicyExists(int insurerId, int insuredId)
        {
            return _policyDal.Get(p => p.InsurerID == insurerId && p.InsuredID == insuredId) != null;
        }

        public bool PolicyExistsByDate(int insurerId, int insuredId, DateTime startDate, DateTime endDate)
        {
            return _policyDal.Get(p => p.InsurerID == insurerId && p.InsuredID == insuredId &&
                                        p.StartDate <= endDate && p.EndDate >= startDate) != null;
        }
    }
}



