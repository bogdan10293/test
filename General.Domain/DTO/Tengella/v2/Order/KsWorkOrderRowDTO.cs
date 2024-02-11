using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Order
{
    public class KsWorkOrderRowDTO
    {
        public int WorkOrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int CostPrice { get; set; }
        public int ApproxWorkingTime { get; set; }
    }
}
