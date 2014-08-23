using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
namespace ToDo.Domain.Abstract
{
    interface IToDoRepository
    {

        IEnumerable<ToDoEntity> GetToDos(int userId);
        bool AddToDo(ToDoEntity toDo);
        bool DeleteToDo(int toDoId);
        bool EditToDo(ToDoEntity toDo);


        IDictionary<int, string> GetStatusValues();
        IDictionary<int, string> GetPriorityValues();
        UserEntity GetToDOUser(int id);
        PriorityEntity GetPrioritybyID(int id);
        StatusEntity GetStatusbyID(int id);
        PriorityEntity GetPrioritybyValue(String value);
        StatusEntity GetStatusbyValue(String value);

    }

}
