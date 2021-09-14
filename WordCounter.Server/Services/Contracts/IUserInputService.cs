using System;
namespace WordCounter.Server.Services
{
    public interface IUserInputService
    {
        long ParseUserInput(string input);
    }
}
