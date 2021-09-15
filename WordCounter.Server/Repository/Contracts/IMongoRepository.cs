using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordCounter.Server.Repository
{
    public interface IMongoRepository
    {
        void InitConnection(string host, string username, string password, string database);
        Task<BsonDocument> GetRecordById(string document, string docId);
    }
}
