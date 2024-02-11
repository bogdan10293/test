using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsOrderServiceWindowTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfWindowSides { get; set; }
        public int Quantity { get; set; }
        public int OrderServiceFK { get; set; }
        public KsOrderServiceEntity Service { get; set; }
    }
}
