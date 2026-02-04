using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

using WebInterface.EventSystem;

namespace ProjectTemplate.HTTPBackend {
    public class HTTPServer {
        public HTTPServer(int port = 8080, string webRoot = "wwwroot")
        {
            this._port = port;
            this._webroot = webRoot;
        }

        public void Start()
        {
            if (_serverTask != null)
            {
                //server running
                _httpLog.Raise(EventSystem.LogLevel.Log, $"HTTP Application {_applicationName} is already running.");
                return;
            }

            if (_locked)
            {
                //process locked
                _httpLog.Raise(EventSystem.LogLevel.Error, $"HTTP Application {_applicationName} Locked");
                return;
            }

            _locked = true;

            WebApplicationBuilder _builder = WebApplication.CreateBuilder();

            _builder.Logging.ClearProviders();
            //readd custom provider later
            //_builder.Logging.AddProvider();

            _builder.WebHost.ConfigureKestrel(options => {
                options.ListenAnyIP(_port);
            });

            _app = _builder.Build();

            if (_webroot != "webroot")
            {
                string fileRoot = Path.Combine(Directory.GetCurrentDirectory(), _webroot);
                _app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(fileRoot), RequestPath = "" });
            } else
            {
                _app.UseStaticFiles();
            }

            //Logger middleware
            _app.Use(async (context) => {
                _httpLog.Raise(EventSystem.LogLevel.Log, $"[{DateTime.Now:HH:mm:ss}] {context.Request.Method} {context.Request.Path}");
                await next();
            });

            _app.Run(async context => {
                HttpRequest _req = context.Request;
                HttpResponse _res = context.Response;

                //Insert routing code here, send copies of - context, _req and _res
                _router.Raise(_req.Path, context, _req, _res)
            })

            _serverTask = _app.RunAsync();
            _locked = false;
        }

        public async Task Stop()
        {
            if (_serverTask == null)
            {
                //Error - Server Not Running Log
                _httpLog.Raise(EventSystem.LogLevel.Warning, $"HTTP Application {_applicationName} is not running, so cannot be stopped.");
                return;
            }

            if (_app == null)
            {
                //Error - Server Not Setup Log!
                _httpLog.Raise(EventSystem.LogLevel.Warning, $"HTTP Application {_applicationName} has no WebApp component setup.");
                return;
            }

            if (_locked)
            {
                //Error - Process is currently locked
                _httpLog.Raise(EventSystem.LogLevel.Error, $"HTTP Application {_applicationName} Locked");
                return;
            }

            _locked = true;

            await _app.StopAsync();
            _serverTask = null;
            _locked = false;
        }

        private string _applicationName = "New HTTP App";
        private bool _locked = false;
        private WebApplication? _app = null;
        private Task? _serverTask = null;
        private int _port = 0;
        private string _webroot = "";
        private HTTPRouter _router = new();
        //Events
        private Event_Log _httpLog = new();
    }
}
