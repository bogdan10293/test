using General.Domain.Joins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General.Domain.ViewModels.KsStad
{
    public class KsServiceAdditionalViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public double Price { get; set; }
        public bool Rut { get; set; }
        public TimeSpan Duration { get; set; }
        public int Quantity { get; set; }
        public KsServiceViewModel Service { get; set; }
        public int ServiceFk { get; set; }
    }
}
