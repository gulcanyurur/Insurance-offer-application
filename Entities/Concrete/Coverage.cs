using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Coverage : IEntity
    {
        public int CoverageID { get; set; }
        public string CoverageName { get; set; }
        public string Description { get; set; }
        public decimal PremiumTL { get; set; }
        public decimal PremiumUSD { get; set; }

       
    }
}




