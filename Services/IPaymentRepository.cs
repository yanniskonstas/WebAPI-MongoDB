using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Form3Api.Models;

namespace Form3Api.Services
{    
    public interface IPaymentRepository
    {
        Payment Get(string id);    
        IEnumerable<Payment> Get();
        IEnumerable<Payment> Get(IEnumerable<string> ids);
        void Add(Payment payment);
        void Update(string id, Payment payment);
        void Delete(string id);          
    }
}
