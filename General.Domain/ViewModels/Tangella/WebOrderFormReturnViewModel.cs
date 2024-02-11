using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace General.Domain.ViewModels.Tangella

{
    [Serializable()]
    public class WebOrderFormReturnViewModel
    {
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal QuotedPrice { get; set; }
        [DataMember]
        public bool IsIncludingVAT { get; set; }
        [DataMember]
        public bool IsPrivate { get; set; }
        [DataMember]
        public string OrderDate { get; set; }
        [DataMember]
        public int? WhenInTheDayId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string WorkAddressStreet { get; set; }
        [DataMember]
        public string WorkAddressZipCode { get; set; }
        [DataMember]
        public string WorkAddressCity { get; set; }
        [DataMember]
        public string RegNo { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public bool? SendConfirmationEmail { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public bool? SendInvoiceByEmail { get; set; }
        [DataMember]
        public bool? OtherInvoiceAddress { get; set; }
        [DataMember]
        public string InvoiceAddressStreet { get; set; }
        [DataMember]
        public string InvoiceAddressZipCode { get; set; }
        [DataMember]
        public string InvoiceAddressCity { get; set; }
        [DataMember]
        public string HowDoWeGetIn { get; set; }
        [DataMember]
        public bool? CleaningMaterialsOnSite { get; set; }
        [DataMember]
        public bool? FurAnimalsIsOnSite { get; set; }
        [DataMember]
        public List<WebOrderFormRowReturnViewModel> WebOrderFormRows { get; set; }
    }
}
