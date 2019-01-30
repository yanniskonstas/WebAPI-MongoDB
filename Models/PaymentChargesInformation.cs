using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Form3Api.Models
{
    public class PaymentChargesInformation
    {
        [BsonElement("bearer_code")]
        [BsonRequired]
        public string BearerCode { get; set; }        

        [BsonElement("sender_charges")]
        public IEnumerable<PaymentAttributes> SenderCharges { get; set; }    
    } 
}
