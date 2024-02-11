using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class CustomerResponseModel
    {
        public int CustomerId { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public List<AddressesResponseModel> Addresses { get; set; }
        public List<ContactsResponseModel> Contacts { get; set; }
    }
}
