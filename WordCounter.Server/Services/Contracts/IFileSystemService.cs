using System.Threading.Tasks;

namespace WordCounter.Server.Services.Contracts
{
    public interface IFileSystemService
    {
        Task<long> ParseFileAsync(string location);
    }
}
