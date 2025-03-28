using DotNet8.VerticleSlice_CQRSExample.Api.Repositories.Blog;

namespace DotNet8.VerticleSlice_CQRSExample.Api
{
	public static class ModularService
	{

		private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IBlogRepository, BlogRepository>();
			return services;
		}

	}
}
