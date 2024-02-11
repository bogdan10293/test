using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Order
{
    public class KsWorkOrderDTO
    {
        public int ProjectId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DesiredScheduleDate { get; set; }
        public string WorkOrderDescription { get; set; }
        public string KeyReturn { get; set; }
        public string KeyAccess { get; set; }
        public string Message { get; set; }
        public string PortalCode { get; set; }
        public List<KsWorkOrderRowDTO> WorkOrderRows { get; set; }

    }
}
