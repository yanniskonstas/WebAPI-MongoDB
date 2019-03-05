using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form3Api.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Form3Api.Services
{    
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("form3Db"));
            var database = client.GetDatabase("form3");
            _users = database.GetCollection<User>("users");
        }

        public User Get(string id) {
            return _users.Find(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<User> Get(){
            return _users.Find(p => true).ToList();
        }
        public void Add(User user){
            _users.InsertOne(user);
        }
        public void Update(string id, User user){
            _users.ReplaceOne(p => p.Id == user.Id, user);
        }
        public void Delete(string id){
            _users.DeleteOne(p => p.Id == id);
        }
    }
}
