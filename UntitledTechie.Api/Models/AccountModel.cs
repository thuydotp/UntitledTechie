using System;

namespace UntitledTechie.Api.Models
{
    public class AccountModel: BaseModel
    {
        public string Username { get; set; }

        public Guid AvatarImageId { get; set; }
        
        public string Secret { get; set; }
    }
}