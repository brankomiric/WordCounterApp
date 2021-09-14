namespace WordCounter.Server.DTOs
{
    public class DatabaseSourceRequestDTO : BaseRequestDTO
    {
        public StorageConfigDTO Config { get; set; }
    }
}
