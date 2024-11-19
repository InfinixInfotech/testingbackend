using Microsoft.Extensions.Options;
using Models.Common;
using MongoDB.Driver;


namespace Common
{
    public class SequenceGenerator
    {
        private readonly IMongoDatabase _database;

        public SequenceGenerator(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        // Method to get the next sequence number from a specified collection
        public int GetNextSequence(string collectionName, string sequenceName)
        {
            var sequenceCollection = _database.GetCollection<DatabaseSequence>(collectionName);

            // Define a filter to search for the sequenceName
            var filter = Builders<DatabaseSequence>.Filter.Eq("_id", sequenceName);

            // Define an update to increment the 'seq' field by 1
            var update = Builders<DatabaseSequence>.Update.Inc("seq", 1);

            // Set options to return the updated document and perform upsert if the document doesn't exist
            var options = new FindOneAndUpdateOptions<DatabaseSequence>
            {
                ReturnDocument = ReturnDocument.After, // Return the updated document
                IsUpsert = true                        // Create the document if it doesn't exist
            };

            // Perform the FindOneAndUpdate operation
            var counter = sequenceCollection.FindOneAndUpdate(filter, update, options);

            // Return the new sequence value (or 1 if the document was just created)
            return counter != null ? counter.Seq : 1;
        }

        // Method to get the next sequence number and generate a string ID
        public string GetNextStringSequence(string collectionName, string sequenceName)
        {
            int nextSeq = GetNextSequence(collectionName, sequenceName);
            return $"ID_{nextSeq}";  // Example: "ID_1", "ID_2", etc.
        }
    }
}
