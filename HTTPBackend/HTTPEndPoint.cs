using Microsoft.AspNetCore.Http;

namespace ProjectTemplate.HTTPBackend
{
    public abstract class HTTPEndPoint
    {
        protected string pName = "";

        public HTTPEndPoint(string _path)
        {
            pName = _path;
        }

        public async Task Trigger(string _path, HttpContext _context, HttpRequest _req, HttpResponse _res)
        {
            if (_path != pName)
            {
                return;
            }
            await Execute(_context, _req, _res);
        }

        protected virtual async Task Execute(HttpContext _context, HttpRequest _req, HttpResponse _res) { }
    }
}
/*//Example response
                _res.StatusCode = 200;
                _res.ContentType = "text/plain";
                await _res.WriteAsync("Kestral CLI Server is running\n");
                await _res.WriteAsync($"Method: {_req.Method}\n");
                await _res.WriteAsync($"Path: {_req.Path}\n");
                await _res.WriteAsync($"Remote IP: {context.Connection.RemoteIpAddress}\n");
*/