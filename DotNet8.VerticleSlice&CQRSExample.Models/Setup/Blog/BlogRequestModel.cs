namespace DotNet8.VerticleSlice_CQRSExample.Models.Setup.Blog;

public class BlogRequestModel
{
	public string BlogTitle { get; set; } = null!;

	public string BlogAuthor { get; set; } = null!;

	public string BlogContent { get; set; } = null!;
}
