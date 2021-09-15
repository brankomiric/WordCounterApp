using System.Threading.Tasks;

namespace WordCounter.Server.Services
{
    public class SimpleTextParser
    {
        protected Task<long> CountWords(string text)
        {
            var words = text.Split(" ");
            return Task.FromResult<long>(words.Length);
        }
    }

    
}
