using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordCounter.Server.Services;
using WordCounter.Server.Services.Contracts;

namespace WordCounter.Server.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("word_counter")]
    public class WordCounterController: ControllerBase
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IUserInputService _userInputService;
        private readonly IDatabaseService _databaseService;
        private readonly ILogger _logger;
        public WordCounterController(IFileSystemService fileSystemService, IUserInputService userInputService,
                                     IDatabaseService databaseService, ILogger<WordCounterController> logger)
        {
            _fileSystemService = fileSystemService;
            _userInputService = userInputService;
            _databaseService = databaseService;
            _logger = logger;
        }

        [HttpPost("user_input")]
        public async Task<IActionResult> UserInputHandler()
        {
            _logger.LogWarning("this aint no golang!");
            var map = new Dictionary<string, string>()
            {
                { "key", "val1"}
            };
            var task = Task.Run(() => map);
            return Ok(await task);
        }

        [HttpPost("file_system")]
        public async Task<IActionResult> FileSystemHandler()
        {
            var map = new Dictionary<string, string>()
            {
                { "key", "val2"}
            };
            var task = Task.Run(() => map);
            return Ok(await task);
        }

        [HttpPost("database")]
        public async Task<IActionResult> DatabaseHandler()
        {
            var map = new Dictionary<string, string>()
            {
                { "key", "val3"}
            };
            var task = Task.Run(() => map);
            return Ok(await task);
        }
    }
}
