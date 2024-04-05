namespace Infrastructure.Github;
public class GithubSettings
{
	public const string Section = "GithubSettings";

	public string Username { get; set; }
	public string PAT { get; set; }
	public string BasePath { get; set; }
}
