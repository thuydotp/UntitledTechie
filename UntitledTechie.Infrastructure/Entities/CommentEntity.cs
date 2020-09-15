
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UntitledTechie.Infrastructure.Entities
{
    public class BaseCommentEntity: BaseEntityWithAudit
    {
        [Required]
        public string Description { get; set; }

        public Guid PostId { get; set; }
        
        public AccountEntity Creator { get; set; }
    }
    
    [Table("Comment")]
    public class CommentEntity: BaseCommentEntity
    {
        
        public List<SubCommentEntity> SubComments { get; set; }
        
    }

    [Table("SubComment")]
    public class SubCommentEntity: BaseCommentEntity
    {
        public Guid CommentId { get; set; }   
    }    
}