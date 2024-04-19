﻿using eVideoPrime.Core.Entities;

namespace eVideoPrime.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        IEnumerable<User> GetAllUsers();
        bool DeleteUser(int id);
    }
}
