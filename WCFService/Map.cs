using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.WCFService.Contracts;
using ToDo.Domain.Concrete;

namespace ToDo.WCFService
{
    class Map
    {

        public static ToDoEntity ToDoMap(Contracts.ToDo toDo, string userName)
        {
            ToDoRepository rep = new ToDoRepository();
            AccountRepository accountRep = new AccountRepository();

            ToDoEntity EntityToDo = new ToDoEntity();
            EntityToDo.Id = toDo.Id;
            EntityToDo.Title = toDo.Title;
            EntityToDo.Description = toDo.Description;
            EntityToDo.CreateDate = toDo.CreateDate;
            EntityToDo.DeadLine = toDo.DeadLine;
            EntityToDo.StatusEntityId = rep.GetStatusbyValue(toDo.Status).Id;
            EntityToDo.PriorityEntityId = rep.GetPrioritybyValue(toDo.Priority).Id;
            EntityToDo.UserEntityId = accountRep.GetUserId(userName);
            return EntityToDo;
        }

        public static UserEntity UserMap(User user)
        {
            UserEntity EntityUser = new UserEntity();
            EntityUser.UserName = user.UserName;
            EntityUser.Password = user.Password;
            EntityUser.Name = user.Name;
            EntityUser.Surname = user.Surname;
            EntityUser.Address = user.Address;
            EntityUser.E_mail = user.E_mail;
            return EntityUser;
        }


        public static List<Contracts.ToDo> ToDOsMap(IEnumerable<ToDoEntity> toDos)
        {
            ToDoRepository rep = new ToDoRepository();
            List<Contracts.ToDo> list = new List<Contracts.ToDo>();
            foreach (ToDoEntity toDoEntity in toDos)
            {
                Contracts.ToDo tempToDo = new Contracts.ToDo();
                tempToDo.Id = toDoEntity.Id;
                tempToDo.Title = toDoEntity.Title;
                tempToDo.Description = toDoEntity.Description;
                tempToDo.CreateDate = toDoEntity.CreateDate;
                tempToDo.DeadLine = toDoEntity.DeadLine;
                tempToDo.Status = rep.GetStatusbyID(toDoEntity.StatusEntityId).Value.ToString();
                tempToDo.Priority = rep.GetPrioritybyID(toDoEntity.PriorityEntityId).Value.ToString();
                list.Add(tempToDo);
            }
            return list;
        }
    }
}
