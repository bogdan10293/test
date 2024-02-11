using General.Domain.Enums.KsStad;
using General.Domain.Joins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General.Domain.ViewModels.KsStad
{
    public class KsCustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public CustomerModeEnums CustomerMode { get; set; }
        public string CustomerNo { get; set; }
        public string CompanyNo { get; set; }
        public string DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string VatNo { get; set; }
        public string GlnNo { get; set; }
        public string WebUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public InvoiceTypeEnums InvoiceType { get; set; }
        public string InvoiceEmail { get; set; }
        public ICollection<KsAddressViewModel> Address { get; set; }
        public ICollection<KsOrderEntity> Orders { get; set; }
        public ICollection<KsCustomerProjectJoin> KsCustomerProjectJoins { get; set; }

        [NotMapped]
        public List<int> ProjectIds { get; set; }
    }
}
