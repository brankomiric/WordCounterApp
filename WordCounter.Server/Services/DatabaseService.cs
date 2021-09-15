using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.Server.DTOs;
using WordCounter.Server.Services.Contracts;

namespace WordCounter.Server.Services
{
    public class DatabaseService : SimpleTextParser, IDatabaseService
    {
        public Task<long> ParseTextFromDatabase(StorageConfigDTO connectionParams)
        {
            throw new NotImplementedException();
        }
    }
}
