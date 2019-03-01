using BIOMP.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIOMP.Bussiness.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(DbContext context) 
            : base(context)
        {
        }
    }
}
