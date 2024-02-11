using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsSupervisorRoleViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Created {get; set;}
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public string UpdatedBy { get; set; }
    } 
}
