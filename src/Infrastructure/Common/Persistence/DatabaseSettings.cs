namespace Infrastructure.Common.Persistence;
public class DatabaseSettings
{
	public const string Section = "DatabaseSettings";

    public string ConnectionString { get; set; }
}
