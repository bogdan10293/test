using General.Domain.Enums;
using System.Collections.Generic;

namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class KsCustomerDTO
    {
        public CustomerTypeEnums CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string SocialId { get; set; }
        public List<KsAddressDTO> Addresses { get; set; }
        public List<KsContactDTO> Contacts { get; set; }
    }
}
