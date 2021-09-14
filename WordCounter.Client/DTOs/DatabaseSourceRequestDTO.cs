namespace WordCounter.Client.DTOs
{
    public class DatabaseSourceRequestDTO : BaseRequestDTO
    {
        public StorageConfigDTO Config { get; set; }
    }
}
