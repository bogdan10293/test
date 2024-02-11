using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Project
{
    public class KsProjectDTO
    {
        public int CustomerId { get; set; }
        public List<KsProjectContactDTO> Contacts { get; set; }
    }
}
