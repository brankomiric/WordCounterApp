using System.Threading.Tasks;
using WordCounter.Server.DTOs;

namespace WordCounter.Server.Services.Contracts
{
    public interface IDatabaseService
    {
        Task<long> ParseTextFromDatabaseAsync(StorageConfigDTO connectionParams);
    }
}
