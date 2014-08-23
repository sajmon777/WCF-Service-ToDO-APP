using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Entities
{
    [Table("Status")]
    public class StatusEntity
    {
        public StatusEntity()
        {
            ToDos = new List<ToDoEntity>();
        }

        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<ToDoEntity> ToDos { get; set; }

    }
}
