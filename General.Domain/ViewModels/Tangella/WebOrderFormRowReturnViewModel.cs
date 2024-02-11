
using System;
using System.Runtime.Serialization;

namespace General.Domain.ViewModels.Tangella
{
    [Serializable()]
    public class WebOrderFormRowReturnViewModel
    {
        [DataMember]
        public int WebOrderFormRowId { get; set; }
        [DataMember]
        public string WebOrderFormValue { get; set; }
    }
}
