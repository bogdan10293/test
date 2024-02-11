using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace General.Domain.ViewModels.KsStad
{
    public class KsOrderEntity
    {
        [Key]
        public int Id { get; set; }
        public KsCustomerEntity Customer { get; set; }
        public int CustomerFK { get; set; }
        public ICollection<KsOrderServiceEntity> OrderServices { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
