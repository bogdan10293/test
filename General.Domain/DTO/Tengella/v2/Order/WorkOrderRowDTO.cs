using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Order
{
    public class WorkOrderRowDTO
    {
        public WorkOrderRowDTO(KsWorkOrderRowDTO ksOrderRow)
        {
            WorkOrderId = ksOrderRow.WorkOrderId;
            ItemId = ksOrderRow.ItemId;
            Quantity = ksOrderRow.Quantity;
            Price = ksOrderRow.Price;
            CostPrice = ksOrderRow.CostPrice;
            ApproxWorkingTime = ksOrderRow.ApproxWorkingTime;
            CantBeScheduled = false;
        }
        public int? WorkOrderId { get; set; }
        public int? ItemId { get; set; }
        public int? UnitOfMeasureId { get; set; }
        public int? Quantity { get; set; }
        public string Note { get; set; }
        public bool UseHourlyRate { get; set; }
        public int? WorkOrderRoundingId { get; set; }
        public int? Price { get; set; }
        public int? CostPrice { get; set; }
        public int? TotalCostPrice { get; set; }
        public int? ApproxWorkingTime { get; set; }
        public bool CantBeScheduled { get; set; }
        public bool IsManuallyMarkedReady { get; set; }
        public int? SmsReminderId { get; set; }
        public int? SmsContactId { get; set; }
        public string SmsPhoneNumber { get; set; }
        public string SvefakturaOrderLineReference { get; set; }
        public int? TimeSpentForTaxReduction { get; set; }
        public int? AllowedMinutes { get; set; }
        public int? TimebankDebitTime { get; set; }
        public DateTime TimebankTransactionDate { get; set; }
        public string TimebankTransactionNote { get; set; }
    }
}
