namespace ProjectTemplate.HTTPBackend
{
    public class HTTPServer
    {
        public HTTPServer(int port = 8080, string webRoot = "wwwroot")
        {
            
        }

        private string _applicationName = "New HTTP App";
        private bool _locked = false;
        private WebApplication? _app = null;
        private Task? _serverTask = null;
        private int _port = 0;
    }
}
