using NMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.Application
{
    public interface IUserService
    {
        bool Signup(User user);
        object Login(User user);
    }
}
