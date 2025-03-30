namespace DotNet8.VerticleSlice_CQRSExample.Api.Controllers.Blog;

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

	#region GetBlogById

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBlogById(long id)
	{
		try
		{
			var query = new GetBlogByIdQuery() { BlogId = id };
			var item = await _mediator.Send(query);

			return Content(item);
		}	
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion

}
