using General.Domain.ViewModels.KsStad;

namespace General.Domain.ViewModels
{
    public class EmployeeServiceJoin
    {
        public int EmployeeId { get; set; }
        public KsEmployeeViewModel KsEmployee { get; set; }
        public int ServiceId { get; set; }
        public KsServiceViewModel Service { get; set; }
    }
}
