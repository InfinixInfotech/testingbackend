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
    private const string TimeFormat = "HH:mm:ss"; // Format for time only (24-hour clock)

    public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var timeAsString = context.Reader.ReadString(); // Read the time as a string
        // Parse time only, assuming the date is irrelevant (use a base date, e.g., DateTime.MinValue)
        var time = DateTime.ParseExact(timeAsString, TimeFormat, null);
        return time;
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
    {
        // Format the time portion of the DateTime
        var timeAsString = value.ToString(TimeFormat);
        context.Writer.WriteString(timeAsString);
    }
}
