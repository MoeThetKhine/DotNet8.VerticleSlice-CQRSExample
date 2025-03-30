namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Command.CreateBlog;

#region CreateBlogCommandHandler

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand , int>
{
	private readonly IBlogRepository _blogRepository;

	public CreateBlogCommandHandler(IBlogRepository blogRepository)
	{
		_blogRepository = blogRepository;
	}

	public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
	{
		if (string.IsNullOrEmpty(request.BlogRequestModel.BlogTitle))
			throw new Exception("Blog Title cannot be empty.");

		if (string.IsNullOrEmpty(request.BlogRequestModel.BlogAuthor))
			throw new Exception("Blog Author cannot be empty.");

		if (string.IsNullOrEmpty(request.BlogRequestModel.BlogContent))
			throw new Exception("Blog Content cannot be empty.");

		return await _blogRepository.CreateBlogAsync(request.BlogRequestModel);
	}
}

#endregion