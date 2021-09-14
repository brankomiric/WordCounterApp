using System;
using WordCounter.Server.DTOs;

namespace WordCounter.Server.Services.Contracts
{
    public interface IDatabaseService
    {
        long ParseTextFromDatabase(StorageConfigDTO connectionParams);
    }
}
