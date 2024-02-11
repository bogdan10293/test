using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsAddressViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsBillingAddress { get; set; }
        public KsCustomerEntity KsCustomer { get; set; }
        public int KsCustomerFk { get; set; }
    }
}
