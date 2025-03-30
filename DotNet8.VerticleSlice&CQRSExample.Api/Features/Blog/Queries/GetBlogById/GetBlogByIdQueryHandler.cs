namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogById
{
	public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogModel>
	{
		private readonly IBlogRepository _blogRepository;

		public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<BlogModel> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			if (request.BlogId <= 0)
				throw new Exception("Id cannot be empty");

			return await _blogRepository.GetBlogByIdAsync(request.BlogId);
		}
	}
}
