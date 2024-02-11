using General.Domain.ViewModels.KsStad;

namespace General.Domain.Joins
{
    public class KsEmployeeProjectJoin
    {
        public int KsEmployeeId { get; set; }
        public KsEmployeeViewModel KsEmployee { get; set; }
        public int KsProjectId { get; set; }
        public KsProjectViewModel KsProject { get; set; }
    }
}
