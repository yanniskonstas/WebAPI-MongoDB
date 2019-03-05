using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Form3Api.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]        
        public String Id { get; set; }

        [BsonRequired]
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonRequired]
        [BsonElement("lastName")]        
        public string LastName { get; set; }
        
        [BsonElement("dateOfBirth")]
        public DateTimeOffset DateOfBirth { get; set; }

        [BsonElement("dateOfDeath")]
        public DateTimeOffset? DateOfDeath { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }        


    }
}
