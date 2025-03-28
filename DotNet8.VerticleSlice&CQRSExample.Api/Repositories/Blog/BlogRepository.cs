using DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;

namespace DotNet8.VerticleSlice_CQRSExample.Api.Repositories.Blog
{
	public class BlogRepository : IBlogRepository
	{
		private readonly AppDbContext _appDbContext;

		public BlogRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
	}
}
