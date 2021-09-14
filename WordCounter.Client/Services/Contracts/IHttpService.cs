using System;
using System.Threading.Tasks;
using WordCounter.Client.DTOs;

namespace WordCounter.Client.Services.Contracts
{
    public interface IHttpService: IDisposable
    {
        Task<ResponseDTO> MakeRequest(string httpVerb, BaseRequestDTO body, string url);
    }
}
