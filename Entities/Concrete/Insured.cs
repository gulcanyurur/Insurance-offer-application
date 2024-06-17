using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Insured : IEntity
    {
        public int InsuredID { get; set; }
        public string TCKN { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}


