namespace DotNet8.VerticleSlice_CQRSExample.Api.Repositories.Blog;

#region IBlogRepository

public interface IBlogRepository
{
	Task<BlogListResponseModel> GetBlogsAsync();
	Task<BlogModel> GetBlogByIdAsync(long id);
}

#endregion