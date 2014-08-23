using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Concrete;
using ToDo.Domain.Entities;

namespace ToDo.WCFService.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AccountRepositoryTest()
        {
            AccountRepository rep = new AccountRepository();
            UserEntity testUser = rep.GetUserbyUN("Simon777");
            Assert.IsNull(testUser);  
        }
    }
}
