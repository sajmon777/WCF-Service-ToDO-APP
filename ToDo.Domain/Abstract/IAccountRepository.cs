using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Abstract
{
    interface IAccountRepository
    {
        bool ValidateUser(String userName, string password);
        int GetUserId(string userName);
        bool RegisterUser(UserEntity user);
        UserEntity GetUserbyUN(string userName);
    }
}

