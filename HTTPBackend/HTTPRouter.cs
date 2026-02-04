using Microsoft.AspNetCore.Http;
using WebInterface.EventSystem;

namespace ProjectTemplate.HTTPBackend
{
	public class HTTPRouter : Event<string, HTTPContext, HTTPRequest, HTTPResponse>
	{
		//Path, Context, Request, Response
	}
}