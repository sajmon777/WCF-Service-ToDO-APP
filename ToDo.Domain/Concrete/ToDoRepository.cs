using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Abstract;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Concrete
{
    public class ToDoRepository : IToDoRepository
    {


        public IEnumerable<ToDoEntity> GetToDos(int userId)
        {
            using (ToDoContext context = new ToDoContext())
            {
                return context.ToDos.Where(x => x.UserEntityId == userId).ToList();
            }
        }

        public bool AddToDo(ToDoEntity toDo)
        {
            using (ToDoContext context = new ToDoContext())
            {
                try
                {
                    context.ToDos.Add(toDo);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public bool DeleteToDo(int toDoId)
        {
            using (ToDoContext context = new ToDoContext())
            {
                try
                {
                    ToDoEntity delete = context.ToDos.Where(x => x.Id == toDoId).First();
                    context.Entry(delete).State = EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool EditToDo(ToDoEntity toDo)
        {
            using (ToDoContext context = new ToDoContext())
            {
                try
                {
                    context.ToDos.Attach(toDo);
                    context.Entry(toDo).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IDictionary<int, string> GetStatusValues()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            using (ToDoContext context = new ToDoContext())
            {
                list = context.Status.ToDictionary(x => x.Id, x => x.Value);
            }
            return list;
        }


        public IDictionary<int, string> GetPriorityValues()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            using (ToDoContext context = new ToDoContext())
            {
                list = context.Priority.ToDictionary(x => x.Id, x => x.Value);
            }
            return list;
        }



        public PriorityEntity GetPrioritybyID(int id)
        {
            using (ToDoContext context = new ToDoContext())
            {
                return context.Priority.Where(x => x.Id == id).First();
            }

        }

        public StatusEntity GetStatusbyID(int id)
        {
            using (ToDoContext context = new ToDoContext())
            {
                return context.Status.Where(x => x.Id == id).First();
            }
        }


        public UserEntity GetToDOUser(int id)
        {
            using (ToDoContext context = new ToDoContext())
            {
                return context.ToDos.Where(x => x.Id == id).Select(x => x.User).First();
            }
        }


        public PriorityEntity GetPrioritybyValue(string value)
        {

            try
            {
                using (ToDoContext context = new ToDoContext())
                {
                    return context.Priority.Where(x => x.Value == value).First();
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public StatusEntity GetStatusbyValue(string value)
        {
            try
            {
                using (ToDoContext context = new ToDoContext())
                {
                    return context.Status.Where(x => x.Value == value).First();
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
