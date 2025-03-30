namespace DotNet8.VerticleSlice_CQRSExample.Api.Repositories.Blog;

public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext _appDbContext;

	public BlogRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetBlogListAsync

	public async Task<BlogListResponseModel> GetBlogsAsync()
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

	#region GetBlogByIdAsync

	public async Task<BlogModel> GetBlogByIdAsync(long id)
	{
		try
		{
			var item = await _appDbContext.TblBlogs
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.BlogId == id)
				?? throw new Exception("No data found");

			return item.Change();

		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	#endregion

	public async Task<int> CreateBlogAsync(BlogRequestModel requestModel)
	{
		try
		{
			await _appDbContext.TblBlogs.AddAsync(requestModel.Change());
			return await _appDbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

}
