﻿using DotNet8.VerticleSlice_CQRSExample.Api.Repositories.Blog;
using DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.VerticleSlice_CQRSExample.Api;

public static class ModularService
{

	#region AddServices

	public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
	{
		services.AddRepositoryServices()
			.AddDbContextService(builder)
			.AddMediatRService()
			.AddJsonServices();

		return services;
	}

	#endregion

	private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
	{
		services.AddScoped<IBlogRepository, BlogRepository>();
		return services;
	}

	private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<AppDbContext>(opt =>
		{
			opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
		}, ServiceLifetime.Transient);

		return services;
	}

	private static IServiceCollection AddMediatRService(this IServiceCollection services)
	{
		services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
		return services;
	}

	private static IServiceCollection AddJsonServices(this IServiceCollection services)
	{
		services.AddControllers().AddJsonOptions(opt =>
		{
			opt.JsonSerializerOptions.PropertyNamingPolicy = null;
		});

		return services;
	}


}
