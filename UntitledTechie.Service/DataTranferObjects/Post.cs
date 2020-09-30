using System;
using System.Collections.Generic;

namespace UntitledTechie.Service.DataTranferObjects
{
    public class Post: BaseDTOWithAudit
    {
        public List<Guid> ImageIds { get; set; }
        public string Caption { get; set; }
        public int NumberOfLikes { get; set; }
    }
}