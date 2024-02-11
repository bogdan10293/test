using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.ViewModels.KsStad
{
    public class KsApiResultViewModel<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
