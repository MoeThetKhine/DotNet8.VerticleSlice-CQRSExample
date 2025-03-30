namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Command.UpdateBlog;

public class UpdateBlogCommand  : IRequest<int>
{
	public BlogRequestModel BlogRequestModel { get; set; }
	public long BlogId {  get; set; }
}
