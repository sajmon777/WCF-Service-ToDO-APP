using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDo.Domain.Entities
{
    [Table("User")]
    public class UserEntity
    {
        public UserEntity()
        {
            ToDos = new List<ToDoEntity>();
        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string E_mail { get; set; }


        public virtual ICollection<ToDoEntity> ToDos { get; set; }

    }
}