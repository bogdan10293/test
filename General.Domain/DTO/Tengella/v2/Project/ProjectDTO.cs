using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Project
{
    public class ProjectDTO
    {
        public ProjectDTO(KsProjectDTO ksProject)
        {
            CustomerId = ksProject.CustomerId;
            ProjectName = "Projekt från hemsidan";
            SupervisorId = 697;
            OurReferenceId = 424;
            SellerId = 181;
            RegionId = 1084; // fixa dynamiskt från hemsidan if(zipCode) {...}
            Contacts = ksProject.Contacts.Select(x => new ProjectContactDTO(x)).ToList();
            //WorkAddressId = 419251;
            //InvoiceAddressId = 419250;
            //YourRefContactId = ksProject.CustomerId;
        }
        public int? CustomerId { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public int? SupervisorId { get; set; }
        public int? RegionId { get; set; }
        public int? InvoiceAddressId { get; set; }
        public int? DeliveryAddressId { get; set; }
        public int? WorkAddressId { get; set; }
        public int? YourRefContactId { get; set; }
        public int? OurReferenceId { get; set; }
        public int? ProjectInvoiceFilterId { get; set; }
        public string CleaningRoomDescription { get; set; }
        public string SpecialRegulationDescription { get; set; }
        public string AnimalDescription { get; set; }
        public string FlooringDescription { get; set; }
        public string AreaDescription { get; set; }
        public string Digicode { get; set; }
        public string DigicodeDescription { get; set; }
        public string AlarmCode { get; set; }
        public string AlarmCodeDescription { get; set; }
        public string Note { get; set; }
        public bool BatchAllOnOneInvoiceOnThisProject { get; set; }
        public string InternalNote { get; set; }
        public string CleaningDescription { get; set; }
        public string CleaningRequest { get; set; }
        public string OrderConfirmationFinalText { get; set; }
        public string NoteForSchedule { get; set; }
        public string WashingMachineDesc { get; set; }
        public string QualityControlInstruction { get; set; }
        public int? QualityControlsPerYear { get; set; }
        public int? SellerId { get; set; }
        public string DefaultContractInvoiceDescription { get; set; }
        public string DefaultWorkOrderInvoiceDescription { get; set; }
        public string DefaultHourlyRateInvoiceDescription { get; set; }
        public bool RequiresCarAccess { get; set; }
        public string FuseBoxDescription { get; set; }
        public string WindowsDescription { get; set; }
        public bool ExcludeFromBatchInvoice { get; set; }
        public string TaxReductionRealEstateNo { get; set; }
        public string TaxReductionApartmentNo { get; set; }
        public string TaxReductionHousingAssociationRegNo { get; set; }
        public List<ProjectContactDTO> Contacts { get; set; }
 
    }
}
