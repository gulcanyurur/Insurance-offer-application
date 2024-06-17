using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPolicyService
    {
        Policy GetById(int policyId);
        List<Policy> GetAll();
        string Add(Policy policy);
        string Update(Policy policy);
        void Delete(Policy policy);
        bool PolicyExists(int insurerId, int insuredId);
        bool PolicyExistsByDate(int insurerId, int insuredId, DateTime startDate, DateTime endDate);
    }
}



