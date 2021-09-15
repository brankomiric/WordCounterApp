using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordCounter.Server.DTOs;
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
        public async Task<IActionResult> UserInputHandler([FromBody] UserInputRequestDTO dto)
        {
            var wordCount = await _userInputService.ParseUserInputAsync(dto.UserInput);
            var response = new ResponseDTO()
            {
                IsSuccess = true,
                Result = wordCount,
                ErrorMessages = new List<string>()
            };
            return Ok(response);
        }

        [HttpPost("file_system")]
        public async Task<IActionResult> FileSystemHandler([FromBody] FileRequestDTO dto)
        {
            var response = new ResponseDTO();
            try
            {
                var wordCount = await _fileSystemService.ParseFileAsync(dto.FileLocation);
                response.IsSuccess = true;
                response.Result = wordCount;
                response.ErrorMessages = new List<string>();
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Result = null;
                var errors = new List<string>();
                errors.Add(ex.Message);
                response.ErrorMessages = errors;
                return BadRequest(response);
            }
            
        }

        [HttpPost("database")]
        public async Task<IActionResult> DatabaseHandler([FromBody] DatabaseSourceRequestDTO dto)
        {
            var response = new ResponseDTO();
            try
            {
                var wordCount = await _databaseService.ParseTextFromDatabaseAsync(dto.Config);
                response.IsSuccess = true;
                response.Result = wordCount;
                response.ErrorMessages = new List<string>();
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Result = null;
                var errors = new List<string>();
                errors.Add(ex.Message);
                response.ErrorMessages = errors;
                return BadRequest(response);
            }
        }
    }
}
