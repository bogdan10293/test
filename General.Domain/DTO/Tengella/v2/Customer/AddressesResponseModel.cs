using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class AddressesResponseModel
    {
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public bool IsDefaultAddressforType { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
