﻿global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using DotNet8.VerticleSlice_CQRSExample.Api.Repositories.Blog;
global using DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;
global using Microsoft.EntityFrameworkCore;
global using DotNet8.VerticleSlice_CQRSExample.Api;
global using DotNet8.VerticleSlice_CQRSExample.Models;
global using DotNet8.VerticleSlice_CQRSExample.Models.Setup.Blog;
global using MediatR;
global using DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogById;
global using DotNet8.VerticleSlice_CQRSExample.Api.Features.Blog.Queries.GetBlogList;