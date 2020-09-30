using System;

namespace UntitledTechie.Service.DataTranferObjects
{
    public class Account: BaseDTO
    {
        public string Username { get; set; }

        public Guid AvatarImageId { get; set; }
    }
}