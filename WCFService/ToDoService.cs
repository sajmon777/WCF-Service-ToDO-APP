using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.WCFService.Contracts;
using ToDo.Domain.Concrete;
using ToDo.Domain.Entities;
using System.Security.Permissions;
using System.Security.Principal;


namespace ToDo.WCFService
{
    class ToDoService : IToDoService
    {
       
        [PrincipalPermission(SecurityAction.Demand, Role = "Anonymous")]
        public bool RegisterUser(User user)
        {
            AccountRepository rep = new AccountRepository();
            if (rep.GetUserId(user.UserName) == 0)
            {
                return rep.RegisterUser(Map.UserMap(user));
            }
            return false;
        }

      
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public int GetUserId(string userName)
        {
            AccountRepository rep = new AccountRepository();
            return rep.GetUserId(userName);
        }
        
      
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public List<Contracts.ToDo> GetToDos()
        {
            IIdentity identity = Thread.CurrentPrincipal.Identity; 
            ToDoRepository repToDo = new ToDoRepository();
            AccountRepository repAccount = new AccountRepository();
            return Map.ToDOsMap(repToDo.GetToDos(repAccount.GetUserId(identity.Name)));
        }
        
       
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public bool AddToDo(Contracts.ToDo toDO)
        {
            IIdentity identity = Thread.CurrentPrincipal.Identity;
            ToDoRepository rep = new ToDoRepository();
            return rep.AddToDo(Map.ToDoMap(toDO, identity.Name));

        }
        
        
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public bool EditToDo(Contracts.ToDo toDO)
        {
            IIdentity identity = Thread.CurrentPrincipal.Identity;
            ToDoRepository rep = new ToDoRepository();
            AccountRepository accountRep = new AccountRepository();
            UserEntity user = rep.GetToDOUser(toDO.Id);
            if (user.Id == accountRep.GetUserId(identity.Name))
            {
                return rep.EditToDo(Map.ToDoMap(toDO, identity.Name));
            }
            return false;

        }
        
       
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public bool DeleteToDo(int id)
        {
            IIdentity identity = Thread.CurrentPrincipal.Identity;
            ToDoRepository rep = new ToDoRepository();
            AccountRepository accountRep = new AccountRepository();
            UserEntity user = rep.GetToDOUser(id);
            if (user.Id == accountRep.GetUserId(identity.Name))
            {
                return rep.DeleteToDo(id);
            }
            return false;

        }
        
        
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public IDictionary<int, string> GetStatusValues()
        {
            ToDoRepository rep = new ToDoRepository();
            return rep.GetStatusValues();
        }
        
        
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public IDictionary<int, string> GetPriorityValues()
        {
            ToDoRepository rep = new ToDoRepository();
            return rep.GetPriorityValues();
        }
    }
}
