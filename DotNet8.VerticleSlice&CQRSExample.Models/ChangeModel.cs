using DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;
using DotNet8.VerticleSlice_CQRSExample.Models.Setup.Blog;

namespace DotNet8.VerticleSlice_CQRSExample.Models;

public static class ChangeModel
{
	#region Blog Model

	public static BlogModel Change(this TblBlog dataModel)
	{
		return new BlogModel
		{
			BlogId = dataModel.BlogId,
			BlogTitle = dataModel.BlogTitle,
			BlogAuthor = dataModel.BlogAuthor,
			BlogContent = dataModel.BlogContent,
		};
	}

	#endregion

	#region TblBlog

	public static TblBlog Change(this BlogRequestModel requestModel)
	{
		return new TblBlog
		{
			BlogTitle = requestModel.BlogTitle,
			BlogAuthor = requestModel.BlogAuthor,
			BlogContent = requestModel.BlogContent,
		};
	}

	#endregion

}
