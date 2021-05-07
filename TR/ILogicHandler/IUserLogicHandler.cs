namespace TR.ILogicHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TR.Models;

    public interface IUserLogicHandler
    {
        User GetUsers(string user, string password);

        bool UpdateUsers(User user);
    }
}
