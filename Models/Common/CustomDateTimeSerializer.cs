using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class CustomDateTimeSerializer : SerializerBase<DateTime>
    {
        private const string DateFormat = "dd-MM-yyyy";
        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var dateAsString = context.Reader.ReadString();
            return DateTime.ParseExact(dateAsString, DateFormat, null);
        }
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {
            var dateAsString = value.ToString(DateFormat);
            context.Writer.WriteString(dateAsString);
        }
    }
}
public class CustomTimeSerializer : SerializerBase<DateTime>
{
    private const string TimeFormat = "hh:mm tt"; 
    public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var timeAsString = context.Reader.ReadString();
        return DateTime.ParseExact(timeAsString, TimeFormat, null);
    }
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
    {
        var timeAsString = value.ToString(TimeFormat);
        context.Writer.WriteString(timeAsString);
    }
}