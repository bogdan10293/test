using General.Domain.Joins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsProjectViewModel
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string WorkAddress { get; set; }
        public string WorkAddressZipCode { get; set; }
       public ICollection<KsSupervisorProjectJoin> KsSupervisorProjectJoins { get; set; }
        public ICollection<KsCustomerProjectJoin> KsCustomerProjectJoins { get; set; }
        public ICollection<KsEmployeeProjectJoin> KsEmployeeProjectJoins { get; set; }
        [NotMapped]
        public List<int> KsCustomerIds { get; set; }
        [NotMapped]
        public List<int> KsSupervisorIds { get; set; }
    }
}
