namespace DotNet8.VerticleSlice_CQRSExample.Api.Repositories.Blog;

public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext _appDbContext;

	public BlogRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetBlogListAsync

	public async Task<BlogListResponseModel> GetBlogListAsync()
	{
		try
		{
			var dataLst = await _appDbContext.TblBlogs
				.AsNoTracking()
				.OrderByDescending(x => x.BlogId)
				.ToListAsync();

			var lst = dataLst.Select(x => x.Change()).ToList();

			BlogListResponseModel responseModel = new()
			{
				DataLst = lst
			};

			return responseModel;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	#endregion

}
