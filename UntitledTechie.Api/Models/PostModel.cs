using System;
using System.Collections.Generic;

namespace UntitledTechie.Api.Models
{
    public class PostModel: BaseModelWithAudit
    {
        public List<Guid> ImageIds { get; set; }
        public string Caption { get; set; }
        public int NumberOfLikes { get; set; }
    }
}