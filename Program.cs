using ProjectTemplate.HTTPBackend;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HTTPServer _server = new();

            ProjectTemplate.EndPoints.Time _time = new("/time");
            _server.router.RegisterListener(_time.Trigger);

            bool _running = true;
            _server.Start();

            while (_running)
            {
                Console.Write(": ");
                string? cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    _running = false;
                }
            }
            _server.Stop();
        }
    }
}
