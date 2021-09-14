namespace WordCounter.Client.Services.Contracts
{
    public interface IWordCounterService
    {
        long ProcessFile();
        long ProcessDbEntry();
        long ProcessUserInput();
    }
}
