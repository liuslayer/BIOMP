using BIOMP.Bussiness.Interface;
using BIOMP.Web.Controllers;
using BIOMP.Web.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BIOMP.Web.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        IUnityContainer container;
        public UsersControllerTest()
        {
            container = UnityContainerFactory.GetContainer();
        }

        [TestMethod]
        public void LoginTest()
        {
            var userService = container.Resolve<IUserService>();
            // 排列
            UsersController controller = new UsersController(userService);

            // 操作
            var result = controller.Login("Admin","123456");

            // 断言
            Assert.IsNotNull(result);
            var JResult = JObject.Parse(result);
            Assert.AreEqual("True", JResult["Result"].ToString());
        }

        [TestMethod]
        public void GetUserByIDTest()
        {
            var userService = container.Resolve<IUserService>();
            // 排列
            UsersController controller = new UsersController(userService);

            // 操作
            var result = controller.GetUserByID(2);

            // 断言
            Assert.IsNotNull(result);
        }
    }
}
