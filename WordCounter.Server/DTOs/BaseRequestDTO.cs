namespace WordCounter.Server.DTOs
{
    public enum Type
    {
        FILE, DATABASE, USER_INPUT
    }
    public class BaseRequestDTO
    {
        public Type Type { get; set; }
    }
}
