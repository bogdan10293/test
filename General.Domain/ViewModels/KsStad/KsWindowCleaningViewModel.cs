using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsWindowCleaningViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Rut { get; set; }
        public ICollection<EmployeeServiceJoin> EmployeeServiceJoins { get; set; }
        public ICollection<KsServiceAdditionalViewModel> AdditionalServices { get; set; }
        public ICollection<KsWindowTypeViewModel> WindowTypes { get; set; }
    }
}
