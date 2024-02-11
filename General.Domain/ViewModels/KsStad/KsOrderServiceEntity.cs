using General.Domain.Enums.KsStad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace General.Domain.ViewModels.KsStad
{
    public class KsOrderServiceEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public MainServiceTypeEnums MainServiceType { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public int OrderFK { get; set; }
        public KsOrderEntity Order { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<KsOrderServiceAdditionalEntity> AdditionalServices { get; set; }
        public ICollection<KsOrderServiceWindowTypeEntity> WindowTypes { get; set; }
    }
}
