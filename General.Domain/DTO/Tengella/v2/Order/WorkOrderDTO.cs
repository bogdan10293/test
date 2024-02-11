using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Order
{
    public class WorkOrderDTO
    {
        public WorkOrderDTO(KsWorkOrderDTO ksWorkOrder)
        {
            ProjectId = ksWorkOrder.ProjectId;
            OrderDate = ksWorkOrder.OrderDate;
            DesiredScheduleDate = ksWorkOrder.DesiredScheduleDate;
            WorkOrderDescription = $"WebOrder {ksWorkOrder.WorkOrderDescription}"; // change to serviceType name
            SellerId = 181;
            OurReferenceId = 424;
            WorkInHolidayPeriod = false;
            DesiredSchedulePeriodId = 1;
            WorkOrderRows = ksWorkOrder.WorkOrderRows.Select(x => new WorkOrderRowDTO(x)).ToList();
            Note = $"Tillgång till bostad: {ksWorkOrder.KeyAccess}\n\n Lämning av nycklar: {ksWorkOrder.KeyReturn}\n\n Portkod:{ksWorkOrder.PortalCode}";
            NoteForSchedule = $"{ksWorkOrder.Message}";
        }
        public int ProjectId { get; set; }
        public string WorkOrderNo { get; set; }
        public int? InvoiceAddressId { get; set; }
        public int? WorkAddressId { get; set; }
        public int? YourReferenceContactId { get; set; }
        public string WorkOrderDescription { get; set; }
        public string Note { get; set; }
        public string NoteForSchedule { get; set; }
        public int SellerId { get; set; }
        public int  OurReferenceId { get; set; }
        public string InternalNote { get; set; }
        public int? WorkOrderInvoiceLockStateId { get; set; }
        public string WorkOrderInvoiceDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public int AllowedMinutes { get; set; }
        public int? ConnectedContractId { get; set; }
        public bool WorkInHolidayPeriod { get; set; }
        public bool UseReversedSalestaxAccount { get; set; }
        public int? SieExportOverridePeriodTypeId { get; set; }
        public System.Nullable<int> WorkOrderScreenTypeId { get; set; }
        public bool ExcludeFromBatchInvoice { get; set; }
        public DateTime DesiredScheduleDate { get; set; }
        public int DesiredSchedulePeriodId { get; set; }
        public string DesiredScheduleNote { get; set; }
        public bool CantBeSetAsScheduled { get; set; }
        public int? DesiredScheduleIntervalWeek { get; set; }
        public int? DesiredScheduleIntervalMonth { get; set; }
        public bool DesiredScheduleCopyQuantityAndPrice { get; set; }
        public bool DesiredScheduleCopyProposedEmployee { get; set; }
        public bool HideStartAndEndTimeOnWorkOrderConfirmation { get; set; }
        public int HideEventLengthOnWorkOrderConfirmation { get; set; }
        public string OrderConfirmationFinalText { get; set; }
        public int IsDeleted { get; set; }
        public List<WorkOrderRowDTO> WorkOrderRows { get; set; }
    }
}
