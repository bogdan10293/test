using General.Domain.ViewModels.KsStad;

namespace General.Domain.Joins
{
    public class KsCustomerProjectJoin
    {
        public int KsCustomerId { get; set; }
        public KsCustomerEntity KsCustomer { get; set; }
        public int KsProjectId { get; set; }
        public KsProjectViewModel KsProject { get; set; }
    }
}
