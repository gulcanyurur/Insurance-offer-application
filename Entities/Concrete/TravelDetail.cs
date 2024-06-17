using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class TravelDetail : IEntity
    {
        public int TravelDetailID { get; set; }
        public bool? IsSchengenExcludingUSJapan { get; set; }
        public bool? IsSchengenIncludingUSJapan { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
