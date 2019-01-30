using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form3Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Form3Api.Services
{    
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IMongoCollection<Payment> _payments;

        public PaymentRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("form3Db"));
            var database = client.GetDatabase("form3");
            _payments = database.GetCollection<Payment>("payments");
        }

        public Payment Get(string id) {
            return _payments.Find(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<Payment> Get(){
            return _payments.Find(p => true).ToList();
        }
        public IEnumerable<Payment> Get(IEnumerable<string> ids){
            return _payments.Find(p => ids.Contains(p.Id)).ToList();
        }
        public void Add(Payment payment){
            _payments.InsertOne(payment);
        }
        public void Update(string id, Payment payment){
            _payments.ReplaceOne(p => p.Id == payment.Id, payment);
        }
        public void Delete(string id){
            _payments.DeleteOne(p => p.Id == id);
        }
    }
}
