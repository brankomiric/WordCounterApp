using System.Threading.Tasks;

namespace WordCounter.Server.Services
{
    public interface IUserInputService
    {
        Task<long> ParseUserInputAsync(string input);
    }
}
