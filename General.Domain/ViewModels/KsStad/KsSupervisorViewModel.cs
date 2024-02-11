using General.Domain.Joins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsSupervisorViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public int SupervisorId { get; set; }
        public bool IsDeleted { get; set; } 
        public ICollection<KsEmployeeViewModel> KsEmployees { get; set; }
        public ICollection<KsSupervisorProjectJoin> KsSupervisorProjectJoins { get; set; }
        [NotMapped]
        public List<int> ProjectIds { get; set; }
        [NotMapped]
        public List<int> ProjectRoles { get; set; }
    }
}
