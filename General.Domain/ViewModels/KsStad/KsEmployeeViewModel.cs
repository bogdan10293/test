//using General.Domain.Joins;
using General.Domain.Joins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General.Domain.ViewModels.KsStad
{
    public class KsEmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        public int TangellaId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime? Updated { get; set; }
        public int RegionId { get; set; }
        public bool IsDeleted { get; set; }
        public string EmployeeNo { get; set; }
        public int? SupervisorId { get; set; }
        public string PersonalIdentityNumber { get; set; }
        public KsSupervisorViewModel KsSupervisor { get; set; }
        public int KsSupervisorFK { get; set; }
        public ICollection<EmployeeServiceJoin> EmployeeServiceJoins { get; set; }
        public ICollection<KsEmployeeProjectJoin> KsEmployeeProjectJoins { get; set; }
        
        [NotMapped]
        public List<int> ServiceIds { get; set; }
        [NotMapped]
        public List<int> ProjectIds { get; set; }
    }
}
