namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogById;

public class GetBlogByIdQuery : IRequest<BlogModel>
{
	public long BlogId {  get; set; }
}
