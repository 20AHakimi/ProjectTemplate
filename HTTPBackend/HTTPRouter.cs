using Microsoft.AspNetCore.Http;
using ProjectTemplate.EventSystem;

namespace ProjectTemplate.HTTPBackend
{
	public class HTTPRouter : Event<string, HttpContext, HttpRequest, HttpResponse>
	{
		//Path, Context, Request, Response   
	}
}