using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete
{
    public class Policy : IEntity
    {
        public int PolicyID { get; set; }
        public int? InsurerID { get; set; }
        public int? InsuredID { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPremium { get; set; }
        public string Currency { get; set; }

       
    }
}
