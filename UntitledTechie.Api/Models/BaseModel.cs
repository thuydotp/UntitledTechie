using System;
namespace UntitledTechie.Api.Models
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
    }
    public class BaseModel: BaseModel<Guid>
    {
    }

    public class BaseModelWithAudit<T>: BaseModel<T>
    {
        public T CreatorId { get; set; }
        public T ModifierId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }


    public class BaseModelWithAudit: BaseModelWithAudit<Guid>
    {
    }
}