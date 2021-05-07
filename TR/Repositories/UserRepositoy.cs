namespace TR.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TR.Models;
    using TR.IRepositories;

    public class UserRepositoy : BaseRepository<User>, IUserRepository
    {
        public UserRepositoy(TrContext trContext)
            :base(trContext)
        {

        }
    }
}
