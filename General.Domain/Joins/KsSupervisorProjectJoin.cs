using General.Domain.ViewModels.KsStad;
using System.Collections.Generic;

namespace General.Domain.Joins
{
    public class KsSupervisorProjectJoin
    {
        public int KsSupervisorId { get; set; }
        public KsSupervisorViewModel KsSupervisor { get; set; }
        public int KsProjectId { get; set; }
        public KsProjectViewModel KsProject { get; set; }
        public string SupervisorRole { get; set; }
    }
}
