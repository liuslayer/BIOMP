using BIOMP.Bussiness.Interface;
using BIOMP.EF.Model;
using BIOMP.Web.WebAttribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace BIOMP.Web.Controllers
{
    [BasicAuthorize]
    public class UsersController : ApiController
    {
        #region Identity
        private IUserService _iUserService = null;

        public UsersController(IUserService userService)
        {
            this._iUserService = userService;
        }
        #endregion

        #region 用户登陆
        [AllowAnonymous]
        [HttpGet]
        public string Login(string account, string password)
        {
            if (account.Equals("Admin") && password.Equals("123456"))
            {
                FormsAuthenticationTicket ticketObject = new FormsAuthenticationTicket(0, account, DateTime.Now,
                            DateTime.Now.AddHours(24), true, string.Format("{0}&{1}", account, password),
                            FormsAuthentication.FormsCookiePath);
                var result = new { Result = true, Ticket = FormsAuthentication.Encrypt(ticketObject) };
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = new { Result = false };
                return JsonConvert.SerializeObject(result);
            }
        }
        #endregion

        [AllowAnonymous]
        [HttpGet]
        public User GetUserByID(int id)
        {
            User user = _iUserService.Find<User>(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
                //throw new Exception("textex");
            }
            return user;
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
            User user = new User() { UserName = "Admin", Password = "123456", CreateTime = DateTime.Now };
            _iUserService.Insert<User>(user);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
