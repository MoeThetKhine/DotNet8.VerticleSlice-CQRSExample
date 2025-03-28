using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.VerticleSlice_CQRSExample.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		protected IActionResult Content(object? obj)
		{
			return Content(JsonConvert.SerializeObject(obj), "application/json");
		}
	}
}
