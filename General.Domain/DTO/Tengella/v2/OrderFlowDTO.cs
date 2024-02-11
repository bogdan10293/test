using General.Domain.DTO.Tengella.v2.Customer;
using General.Domain.DTO.Tengella.v2.Order;
using General.Domain.DTO.Tengella.v2.Project;

namespace General.Domain.DTO.Tengella.v2
{
    public class OrderFlowDTO
    {
        public KsCustomerDTO Customer { get; set; }
        public KsProjectDTO Project { get; set; }
        public KsWorkOrderDTO Order { get; set; }
    }
}
