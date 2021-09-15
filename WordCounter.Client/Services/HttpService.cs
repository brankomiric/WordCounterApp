using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Client.DTOs;
using WordCounter.Client.Services.Contracts;

namespace WordCounter.Client.Services
{
    public class HttpService : IHttpService
    {
        private const string baseUrl = "http://localhost:3000/word_counter";
        private readonly IHttpClientFactory _httpClient;
        public HttpService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO> MakeRequest(string httpVerb, BaseRequestDTO body, string url)
        {
            try
            {
                var client = _httpClient.CreateClient("Default");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri($"{baseUrl}/{url}");
                client.DefaultRequestHeaders.Clear();
                if (body != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(body),
                        Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch (httpVerb)
                {
                    case "POST":
                        message.Method = HttpMethod.Post;
                        break;
                    case "PUT":
                        message.Method = HttpMethod.Put;
                        break;
                    case "DELETE":
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var response = await apiResponse.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO>(response);
                return responseDto;
            } catch(Exception ex)
            {
                var dto = new ResponseDTO
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                return dto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
