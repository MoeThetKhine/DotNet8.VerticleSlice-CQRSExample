using MediatR;

namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogList
{
	public class GetBlogListQuery : IRequest<BlogListResponseModel>
	{
	}
}
