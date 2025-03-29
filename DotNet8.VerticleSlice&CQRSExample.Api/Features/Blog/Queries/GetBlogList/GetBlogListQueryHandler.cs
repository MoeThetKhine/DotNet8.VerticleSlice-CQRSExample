namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogList;

public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, BlogListResponseModel>
{
	private readonly IBlogRepository _blogRepository;

	public GetBlogListQueryHandler(IBlogRepository blogRepository)
	{
		_blogRepository = blogRepository;
	}

	public async Task<BlogListResponseModel> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
	{
		return await _blogRepository.GetBlogsAsync();
	}
}
