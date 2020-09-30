using System;
namespace UntitledTechie.Service.DataTranferObjects
{
    public class BaseDTO<T>
    {
        public T Id { get; set; }
    }
    public class BaseDTO: BaseDTO<Guid>
    {
    }

    public class BaseDTOWithAudit<T>: BaseDTO<T>
    {
        public T CreatorId { get; set; }
        public T ModifierId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }


    public class BaseDTOWithAudit: BaseDTOWithAudit<Guid>
    {
    }
}