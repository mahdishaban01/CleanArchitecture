namespace HR_Management.Application.Responses
{
    public class BaseCommandResponse
    {
        public long Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
