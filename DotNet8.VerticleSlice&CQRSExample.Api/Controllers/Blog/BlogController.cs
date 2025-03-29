using DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogList;

namespace DotNet8.VerticleSlice_CQRSExample.Api.Controllers.Blog
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : BaseController
	{
		private readonly IMediator _mediator;

		public BlogController(IMediator mediator)
		{
			_mediator = mediator;
		}

		#region GetBlogs

		[HttpGet]
		public async Task<IActionResult> GetBlogs()
		{
			try
			{
				var query = new GetBlogListQuery();
				var lst = await _mediator.Send(query);

				return Content(lst);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		#endregion
	}
}
