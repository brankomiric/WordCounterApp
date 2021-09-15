namespace WordCounter.Client.DTOs
{
    public class StorageConfigDTO
    {
        public string Provider { get; set; } = "MongoDB";
        public string HostUrl { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Table { get; set; }
        public string RecordId { get; set; }

        public string ColumnName { get; set; }
    }
}
