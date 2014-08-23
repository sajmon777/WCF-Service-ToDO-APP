using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Abstract;

namespace ToDo.Domain.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        public bool ValidateUser(string userName, string password)
        {
            using (ToDoContext context = new ToDoContext())
            {
                try
                {
                    if (context.Users.Any(x => x.UserName == userName && x.Password == password))
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }

        }

        public int GetUserId(string userName)
        {
            using (ToDoContext context = new ToDoContext())
            {
                try
                {
                    return context.Users.Where(x => x.UserName == userName).Select(x => x.Id).First();
                }
                catch
                {
                    return 0;
                }
            }

        }

        public bool RegisterUser(Entities.UserEntity user)
        {
            using (ToDoContext context = new ToDoContext())
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;

                }
                catch
                {
                    return false;
                }
            }

        }

        public Entities.UserEntity GetUserbyUN(string userName)
        {
            using (ToDoContext context = new ToDoContext())
            {
                try
                {
                    return context.Users.Where(x => x.UserName == userName).First();
                }
                catch (InvalidOperationException e)
                {
                    return null;
                }
            }
        }
    }
}
