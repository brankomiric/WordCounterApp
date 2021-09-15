using System.Threading.Tasks;

namespace WordCounter.Server.Services.Contracts
{
    public class UserInputService : SimpleTextParser, IUserInputService
    {
        public Task<long> ParseUserInputAsync(string input)
        {
            return base.CountWords(input);
        }
    }
}
