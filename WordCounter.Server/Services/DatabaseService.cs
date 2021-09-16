using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.Server.DTOs;
using WordCounter.Server.Repository;
using WordCounter.Server.Services.Contracts;

namespace WordCounter.Server.Services
{
    public class DatabaseService : SimpleTextParser, IDatabaseService
    {
        private readonly IMongoRepository _mongoRepository;
        public DatabaseService(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public async Task<long> ParseTextFromDatabaseAsync(StorageConfigDTO @params)
        {
            if(@params.Provider.ToLower() != "MongoDB".ToLower())
            {
                throw new Exception("Database currently unsupported. Try with MongoDB");
            }
            _mongoRepository.InitConnection(@params.HostUrl, @params.Username,
                                            @params.Password, @params.Database);
            var record = await _mongoRepository.GetRecordById(@params.Table, @params.RecordId);
            string value;
            try
            {
                value = record.GetValue(@params.ColumnName).AsString;
            }catch (NullReferenceException)
            {
                throw new Exception($"Record not found for id {@params.RecordId}");
            }
            return await base.CountWords(value);
        }
    }
}
