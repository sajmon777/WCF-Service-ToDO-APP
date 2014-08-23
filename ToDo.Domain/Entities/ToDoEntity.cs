using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Entities
{

    [Table("ToDo")]
    public class ToDoEntity
    {
        public ToDoEntity() { }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadLine { get; set; }

        [Column("Status")]
        public int StatusEntityId { get; set; }
        public virtual StatusEntity Status { get; set; }

        [Column("Priority")]
        public int PriorityEntityId { get; set; }
        public virtual PriorityEntity Priority { get; set; }

        [Column("UserId")]
        public int UserEntityId { get; set; }
        public virtual UserEntity User { get; set; }

    }
}
