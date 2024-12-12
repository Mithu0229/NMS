using NMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.Application
{
    public class UserService : IUserService
    {
        private readonly List<User> _userList = new();
        public bool Signup(User user)
        {
            try
            {
                _userList.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public object Login(User user)
        {
            try
            {
                var userObj = _userList.SingleOrDefault(x => x.UserName == user.UserName);
                if (userObj == null)
                {
                    return null;
                }
                else
                {
                    var obj = new
                    {
                        Username = user.UserName,
                        Token = TokenHelper.GenerateJwtToken(user.UserName)
                    };
                    return obj;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
