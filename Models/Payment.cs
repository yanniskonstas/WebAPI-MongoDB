using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Form3Api.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]        
        public String Id { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("version")]
        [BsonDefaultValue(0)]
        public int Version { get; set; }

        [BsonElement("reference")]
        [BsonRequired]
        public string Reference { get; set; }

        [BsonElement("attributes")]
        public PaymentAttributes Attributes { get; set; }

        [BsonElement("charges_information")]
        public PaymentChargesInformation ChargesInformation { get; set; }        

    }
}
