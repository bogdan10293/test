using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Project
{
    public class ProjectContactDTO
    {
        public ProjectContactDTO(KsProjectContactDTO ksProjContact)
        {
            FirstName = ksProjContact.FirstName;
            LastName = ksProjContact.LastName;
            Mobile = ksProjContact.Mobile;
            Email = ksProjContact.Email;
            Phone = "";
            OccupationId = 2243;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? OccupationId { get; set; }

     }
}
