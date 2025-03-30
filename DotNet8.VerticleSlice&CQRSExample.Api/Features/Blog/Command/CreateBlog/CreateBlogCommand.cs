namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Command.CreateBlog;

public class CreateBlogCommand : IRequest<int>
{
	public BlogRequestModel BlogRequestModel { get; set; }
}
