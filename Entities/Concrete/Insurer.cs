using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Insurer : IEntity
    {
        public int InsurerID { get; set; }
        public string TCKN { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool KVKApproval { get; set; }
        public bool ContractApproval { get; set; }
        public bool CommunicationPermission { get; set; }
    }
}
