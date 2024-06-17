using Core.Entities;

namespace Entities.Concrete
{
    public class PolicyCoverage : IEntity
    {
        public int PolicyCoverageID { get; set; }
        public int PolicyID { get; set; }
        public int CoverageID { get; set; }
    }
}

