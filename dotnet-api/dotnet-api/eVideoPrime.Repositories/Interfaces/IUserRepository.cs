using eVideoPrime.Core.Entities;
using eVideoPrime.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVideoPrime.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers();
        bool DeleteUser(int Id);
    }
}
