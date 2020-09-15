using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UntitledTechie.Infrastructure.Entities
{
    
    [Table("Account")]
    public class AccountEntity : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "Username can not have more than 100 characters.")]
        public string Username { get; set; }

        [Required]
        public Guid AvatarImageId { get; set; }

        public List<PostEntity> Posts { get; set; }
    }
}