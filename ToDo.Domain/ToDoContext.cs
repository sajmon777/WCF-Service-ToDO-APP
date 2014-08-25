using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;


namespace ToDo.Domain
{

    public class ToDoContext : DbContext
    {

        public ToDoContext():base("ToDoDB")
        {
        
        }
        public DbSet<ToDoEntity> ToDos { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<PriorityEntity> Priority { get; set; }
    }
}
