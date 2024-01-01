namespace HR_Management.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient => _httpClient;
    }
}
