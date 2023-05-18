using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository
{
    public interface IUserRepository
    {
        User? GetUserByPhone(string phone);

        User? GetUserByEmail(string email);

        User? GetUserById(Guid id);

        void CreateUser(User user);

        bool IsSaveChange();
    }
}