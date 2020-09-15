using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UntitledTechie.Infrastructure.Entities
{
    public class BaseEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
    }
    public class BaseEntity: BaseEntity<Guid>
    {
    }

    public class BaseEntityWithAudit: BaseEntity
    {
        public Guid CreatorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }
    }


}