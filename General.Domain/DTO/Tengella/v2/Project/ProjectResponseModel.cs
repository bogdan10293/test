using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domain.DTO.Tengella.v2.Project
{
    public class ProjectResponseModel
    {
        public int ProjectId { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectContactsResponseModel> Contacts { get; set; }
    }
}
