using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ToDo.WCFService.Contracts
{
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        bool RegisterUser(User user);

        [OperationContract]
        int GetUserId(string userName);

        [OperationContract]
        List<ToDo> GetToDos();

        [OperationContract]
        bool AddToDo(ToDo toDO);

        [OperationContract]
        bool EditToDo(ToDo toDO);

        [OperationContract]
        bool DeleteToDo(int id);

        [OperationContract]
        IDictionary<int, string> GetStatusValues();

        [OperationContract]
        IDictionary<int, string> GetPriorityValues();

    }
}
