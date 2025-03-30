namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogById;

#region GetBlogByIdQuery

public class GetBlogByIdQuery : IRequest<BlogModel>
{
	public long BlogId {  get; set; }
}

#endregion