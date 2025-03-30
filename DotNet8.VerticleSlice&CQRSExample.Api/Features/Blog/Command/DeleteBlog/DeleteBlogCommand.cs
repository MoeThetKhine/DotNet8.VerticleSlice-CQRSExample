namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Command.DeleteBlog;

public class DeleteBlogCommand : IRequest<int>
{
	public long BlogId {  get; set; }
}
