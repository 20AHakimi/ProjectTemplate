using ProjectTemplate.HTTPBackend;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HTTPServer _server = new();
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
