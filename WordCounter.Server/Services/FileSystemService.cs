using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.Server.Services.Contracts;

namespace WordCounter.Server.Services
{
    public class FileSystemService : SimpleTextParser, IFileSystemService
    {
        public async Task<long> ParseFileAsync(string location)
        {
            var content = await File.ReadAllTextAsync(location);
            return await base.CountWords(content);
        }
    }
}
