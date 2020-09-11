using System;

namespace UntitledTechie.Api.DTOs
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public Guid AvatarImageId { get; set; }

    }
}