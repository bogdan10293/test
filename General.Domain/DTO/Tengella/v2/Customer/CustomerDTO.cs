using General.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class CustomerDTO
    {
        public CustomerDTO(KsCustomerDTO ksCustomer)
        {
            CustomerName = $"{ksCustomer.FirstName} {ksCustomer.LastName}";
            Mobile = ksCustomer.Mobile;
            EMail = ksCustomer.Email;
            Note = "Skapad från hemsidan";
            RegNo = ksCustomer.SocialId;
            OurReferenceId = 424;
            SellerId = 181;
            UsePaymentSlip = true;
            SendInvoiceReminderSms = true;
            CustomerNo = "";
            TermsOfPaymentId = 1547;
            Addresses = ksCustomer.Addresses.Select(ad => new AddressDTO(ad)).ToList();
            if(Addresses.Count() == 1)
            {
                var tempAddress = new AddressDTO(ksCustomer.Addresses.First())
                {
                    AddressType = 4
                };
                Addresses.Add(tempAddress);
            }
            Contacts = ksCustomer.Contacts.Select(cn => new ContactDTO(cn)).ToList();
  
            if (ksCustomer.CustomerType == CustomerTypeEnums.Corporate)
            {
                CustomerTypeId = 758;
                UseTaxReduction = false;
            }
            else
            {
                CustomerTypeId = 757;
                UseTaxReduction = true;
                TaxReductionPercent = 100;
            }

        }

        public string? CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string RegNo { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string EMail { get; set; }
        public string Www { get; set; }
        public string Note { get; set; }
        public int TermsOfPaymentId { get; set; }
        public int CustomerTypeId { get; set; }
        public int OurReferenceId { get; set; }
        public string FormerCustomerNo { get; set; }
        public string Alias { get; set; }
        public string TaxReductionPartaker { get; set; }
        public string TaxReductionPartakerRegNo { get; set; }
        public int TaxReductionPercent { get; set; }
        public int? TaxReductionPartakerPercent { get; set; }
        public bool? UsePaymentSlip { get; set; }
        public int? PrintFilterId { get; set; }
        public int? ContractTermsOfPaymentId { get; set; }
        public int? WorkOrderTermsOfPaymentId { get; set; }
        public int? HourlyRateTermsOfPaymentId { get; set; }
        public int SellerId { get; set; }
        public bool? SendInvoiceReminderSms { get; set; }
        public bool UseTaxReduction { get; set; }
        public List<AddressDTO> Addresses { get; set; }
        public List<ContactDTO> Contacts { get; set; }
    }
}
