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

	#region CreateBlog

	[HttpPost]
	public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
	{
		try
		{
			var command = new CreateBlogCommand() { BlogRequestModel = requestModel };
			int result = await _mediator.Send(command);

			return result > 0 ? Created("Creating Successful.") : BadRequest("Creating Fail.");
		}
		catch(Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion

	#region UpdateBlog

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlog([FromBody] BlogRequestModel requestModel, long id)
	{
		try
		{
			var command = new UpdateBlogCommand()
			{
				BlogRequestModel = requestModel,
				BlogId = id
			};
			int result = await _mediator.Send(command);

			return result > 0 ? Accepted("Updating Successful.");
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion

	#region DeleteBlog

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteBlog(long id)
	{
		try
		{
			var command = new DeleteBlogCommand() { BlogId = id };
			int result = await _mediator.Send(command);

			return result > 0 ? Accepted("Deleting Successful.");
		}
		catch(Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion

}
