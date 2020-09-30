using System;

namespace UntitledTechie.Service.DataTranferObjects
{
    public class Comment: BaseDTOWithAudit
    {
        public string Description { get; set; }

        public Guid PostId { get; set; }

        public Guid? ParentCommentId { get; set; }
    }
}