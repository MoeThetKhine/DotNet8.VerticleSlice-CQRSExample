﻿namespace DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Command.UpdateBlog
{
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
	{
		private readonly IBlogRepository _blogRepository;

		public UpdateBlogCommandHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			if (request.BlogId <= 0)
				throw new Exception("Blog Id cannot be empty.");

		}
	}
}
