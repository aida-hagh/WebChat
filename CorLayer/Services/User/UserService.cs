using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorLayer
{
    public class UserService : BaseService, IUserService
    {
        public UserService(ChatContext context) : base(context)
        {
        }

        public async Task<bool> IsExistUser(string userName)
        {
            return await Table<User>().AnyAsync(u => u.UserName == userName.ToLower());
        }

        public async Task<bool> IsExistUser(long userId)
        {
            return await Table<User>().AnyAsync(u => u.Id == userId);
        }

        public async Task<User> UserLogin(LoginViewModel model)
        {
            var user = await Table<User>().SingleOrDefaultAsync(u => u.UserName == model.UserName);

            if (user == null)
                return null;
            var password = model.Password.EncodePasswordMd5();

            if (password != user.Password)
                return null;
            return user;
        }

        public async Task<bool> UserRegister(RegisterViewModel model)
        {
            if (await IsExistUser(model.UserName))
                return false;

            if (model.Password != model.RePassword)
                return false;

            var EncodePass = model.Password.EncodePasswordMd5();
            var user = new User()
            {
                Avatar = "Default.jpg",
                CreateDate = DateTime.Now,
                Password = EncodePass,
                UserName = model.UserName.ToLower(),
            };
            Insert(user);
            await Save();
            return true;

        }
    }
}
