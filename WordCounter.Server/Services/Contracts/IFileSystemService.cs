namespace WordCounter.Server.Services.Contracts
{
    public interface IFileSystemService
    {
        long ParseFile(string location);
    }
}
