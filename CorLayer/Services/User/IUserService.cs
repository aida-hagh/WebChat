using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorLayer
{
    public interface IUserService
    {
        Task<bool> IsExistUser(string userName);
        Task<bool> IsExistUser(long userId);

        Task<bool> UserRegister(RegisterViewModel model);
        Task<User> UserLogin(LoginViewModel model);


    }
}
