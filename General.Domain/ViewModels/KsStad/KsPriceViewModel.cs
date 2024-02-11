using General.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace General.Domain.ViewModels.KsStad
{
    public class KsPriceViewModel
    {
        [Key]
        public int  Id { get; set; }
        public OccuranceTypeEnums OccuranceType { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public double Price { get; set; }
        public SubscriptionTypeEnums SubscriptionType { get; set; }
        public int NumberOfWindowSides { get; set; }
        public TimeSpan Duration { get; set; }
        public double VAT { get; set; }

    }
}
