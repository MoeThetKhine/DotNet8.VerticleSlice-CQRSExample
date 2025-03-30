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

	#region CreateBlogAsync

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

	#endregion

	#region UpdateBlogAsync

	public async Task<int> UpdateBlogAsync(BlogRequestModel request, long id)
	{
		try
		{
			var item = await _appDbContext.TblBlogs
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.BlogId == id) ?? throw new Exception("Blog Id cannot be empty.");

			if (!string.IsNullOrEmpty(request.BlogTitle))
			{
				item.BlogTitle = request.BlogTitle;
			}

			if (!string.IsNullOrEmpty(request.BlogAuthor))
			{
				item.BlogAuthor = request.BlogAuthor;
			}

			if (!string.IsNullOrEmpty(request.BlogContent))
			{
				item.BlogContent = request.BlogContent;
			}

			_appDbContext.Entry(item).State = EntityState.Modified;

			return await _appDbContext.SaveChangesAsync();
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	#endregion

	#region DeleteBlogAsync

	public async Task<int> DeleteBlogAsync(long id)
	{
		try
		{
			var item = await _appDbContext.TblBlogs
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.BlogId == id) ?? throw new("No Data Found.");

			_appDbContext.TblBlogs.Remove(item);

			return await _appDbContext.SaveChangesAsync();
		}

		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	#endregion

}
