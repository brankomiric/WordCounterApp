using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Server.Repository
{
    public class MongoRepository: IMongoRepository
    {
        private IMongoDatabase db;
        private readonly ILogger _logger;

        public MongoRepository(ILogger<MongoRepository> logger)
        {
            _logger = logger;
        }

        public void InitConnection(string host, string username, string password, string database)
        {
            var sb = new StringBuilder("mongodb://", 512);
            if (!string.IsNullOrEmpty(username))
            {
                sb.Append(username);
            }
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                sb.Append(":");
                sb.Append(password);
                sb.Append("@");
            }
            sb.Append(host);
            sb.Append(":27017");
            var connectionString = sb.ToString();
            var client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
            _logger.LogInformation("Mongo Connection established");
        }

        public async Task<BsonDocument> GetRecordById(string document, string docId)
        {
            var collection = db.GetCollection<BsonDocument>(document);
            FilterDefinition<BsonDocument> filter;

            /*
             * in cases where _id is a number and not a string
             * the search would return no results.
             * handling both cases here
             */
            int.TryParse(docId, out int docIdNum);
            if (docIdNum != 0)
            {
                filter = Builders<BsonDocument>.Filter.Eq("_id", docIdNum);
            } else
            {
                filter = Builders<BsonDocument>.Filter.Eq("_id", docId);
            }

            return (await collection.FindAsync(filter)).FirstOrDefault();
        }

    }
}
