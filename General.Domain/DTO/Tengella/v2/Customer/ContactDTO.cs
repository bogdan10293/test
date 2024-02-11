
namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class ContactDTO
    {
        public ContactDTO(KsContactDTO ksContact)
        {
            FirstName = ksContact.FirstName;
            LastName = ksContact.LastName;
            Email = ksContact.Email;
            Mobile = ksContact.Mobile;
            OccupationId = 2247;
            IsDefaultCustomerContact = true;
            Phone = "";
        }
        public bool IsDefaultCustomerContact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public int? OccupationId { get; set; }
    }
}
