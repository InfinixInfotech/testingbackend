using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models.Common
{
    public class BlacklistedToken
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
