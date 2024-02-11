using General.Domain.Enums.KsStad;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class KsAddressDTO
    {
        public CustomerAddressTypeEnums AddressType { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public bool IsDefaultAddress { get; set; }
    }
}
