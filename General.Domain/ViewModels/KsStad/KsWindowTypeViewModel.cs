using General.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsWindowTypeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfWindowSides { get; set; }
        public int Quantity { get; set; }
        public KsServiceViewModel Service { get; set; }
        public int ServiceFk { get; set; }

    }
}
