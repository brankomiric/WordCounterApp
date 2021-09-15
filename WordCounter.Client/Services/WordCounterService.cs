using System;
using System.Threading.Tasks;
using WordCounter.Client.DTOs;
using WordCounter.Client.Services.Contracts;

namespace WordCounter.Client.Services
{
    public class WordCounterService : IWordCounterService
    {
        private readonly IHttpService _httpService;
        public WordCounterService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public long ProcessDbEntry()
        {
            Console.WriteLine("Please provide parameters for connecting to you Database (Only MongoDB is supported currently)");
            var configDto = new StorageConfigDTO();
            Console.WriteLine("Database host (localhost e.g.):");
            configDto.HostUrl = Console.ReadLine();
            Console.WriteLine("Database name:");
            configDto.Database = Console.ReadLine();
            Console.WriteLine("Username (hit Enter if none):");
            configDto.Username = Console.ReadLine();
            Console.WriteLine("Password (hit Enter if none):");
            configDto.Password = Console.ReadLine();
            Console.WriteLine("Collection:");
            configDto.Table = Console.ReadLine();
            Console.WriteLine("Document id:");
            configDto.RecordId = Console.ReadLine();
            Console.WriteLine("Collection field to parse:");
            configDto.ColumnName = Console.ReadLine();
            var reqBodyDto = new DatabaseSourceRequestDTO()
            {
                Type = DTOs.Type.DATABASE,
                Config = configDto
            };
            var response = WaitTaskResult("POST", reqBodyDto, "database");
            return ParseCount(response);
        }

        public long ProcessFile()
        {
            Console.WriteLine("Please enter file location on the disk:");
            string fileLoc = Console.ReadLine().Replace(@"\", "\\");
            var reqBodyDto = new FileRequestDTO()
            {
                Type = DTOs.Type.FILE,
                FileLocation = fileLoc
            };
            var response = WaitTaskResult("POST", reqBodyDto, "file_system");
            return ParseCount(response);
        }

        public long ProcessUserInput()
        {
            Console.WriteLine("Please enter text you wish to have parsed and counted:");
            string text = Console.ReadLine();
            var reqBodyDto = new UserInputRequestDTO()
            {
                Type = DTOs.Type.USER_INPUT,
                UserInput = text
            };
            var response = WaitTaskResult("POST", reqBodyDto, "user_input");
            return ParseCount(response);
        }

        private ResponseDTO WaitTaskResult(string httpVerb, BaseRequestDTO body, string url)
        {
            /*
             * there's no need for a full async flow in a client app
             * running no background tasks, so blocking for results here
             */
            var task = Task.Run(() => _httpService.MakeRequest(httpVerb, body, url));
            task.Wait();
            return task.Result;
        }

        private long ParseCount(ResponseDTO response)
        {
            if (!response.IsSuccess)
            {
                throw new Exception(response.ErrorMessages.ToString());
            }
            else
            {
                return (long)response.Result;
            }
        }
    }
}
