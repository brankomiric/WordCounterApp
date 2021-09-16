using System.Threading.Tasks;

namespace WordCounter.Server.Services
{
    public class SimpleTextParser
    {
        protected Task<long> CountWords(string text)
        {
            string[] words = new string[0];
            if (!string.IsNullOrEmpty(text))
            {
                words = text.Split(" ");
            }
            return Task.FromResult<long>(words.Length);
        }
    }

    
}
