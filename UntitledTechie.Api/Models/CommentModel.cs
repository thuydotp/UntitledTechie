using System;

namespace UntitledTechie.Api.Models
{
    public class CommentModel: BaseModelWithAudit
    {
        public string Description { get; set; }

        public Guid PostId { get; set; }

        public Guid? ParentCommentId { get; set; }
    }
}