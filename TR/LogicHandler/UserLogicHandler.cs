namespace TR.LogicHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TR.ILogicHandler;
    using TR.IRepositories;
    using TR.Models;

    public class UserLogicHandler : IUserLogicHandler
    {
        private readonly IUserRepository userRepository;

        public UserLogicHandler(IUserRepository user)
        {
            userRepository = user;
        }

        /// <summary>
        /// 验证登陆
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUsers(string user, string password)
        {
            return userRepository.Get(x => x.IsDelete == 0 && x.UserName == user && x.Password == password);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdateUsers(User user)
        {
            return userRepository.Update(user);
        }
    }
}
