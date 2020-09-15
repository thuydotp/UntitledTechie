using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UntitledTechie.Infrastructure.Entities
{

    [Table("Post")]
    public class PostEntity : BaseEntityWithAudit
    {
        // public List<Guid> ImageIds { get; set; }
        public Guid ImageId { get; set; }

        [Required]
        public string Caption { get; set; }
        public int NumberOfLikes { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public AccountEntity Creator { get; set; }
    }
}