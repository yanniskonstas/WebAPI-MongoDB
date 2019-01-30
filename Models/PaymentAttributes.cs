using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Form3Api.Models
{
    public class PaymentAttributes
    {
        [BsonElement("amount")]
        [BsonRequired]
        public double Amount { get; set; }        

        [BsonElement("currency")]
        [BsonDefaultValue("GBP")]
        public string Currency { get; set; }    
    } 
}
