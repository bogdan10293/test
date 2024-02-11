using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class ContactsResponseModel
    {
        public int ContactId { get; set; }
        public bool IsDefaultCustomerContact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
