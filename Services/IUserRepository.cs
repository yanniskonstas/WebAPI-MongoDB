using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Form3Api.Entities;

namespace Form3Api.Services
{    
    public interface IUserRepository
    {
        User Get(string id);    
        IEnumerable<User> Get();
        void Add(User user);
        void Update(string id, User user);
        void Delete(string id);          
    }
}
