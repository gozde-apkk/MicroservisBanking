using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsBanking.Common.Entity
{
    public class Customer : BaseEntity  
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Id { get; set; }
        public string? FullName { get; set;}

        public long? CitizenNumber { get; set; }
         public string? Email { get; set;}

        public DateTime BirthDate { get; set; }
    }
}
