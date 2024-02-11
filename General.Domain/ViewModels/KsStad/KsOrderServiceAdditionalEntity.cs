using System;
using System.ComponentModel.DataAnnotations;

namespace General.Domain.ViewModels.KsStad
{
    public class KsOrderServiceAdditionalEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public double Price { get; set; }
        public bool Rut { get; set; }
        public TimeSpan Duration { get; set; }
        public int Quantity { get; set; }
        public int OrderServiceFK { get; set; }
        public KsOrderServiceEntity Service { get; set; }
    }
}
