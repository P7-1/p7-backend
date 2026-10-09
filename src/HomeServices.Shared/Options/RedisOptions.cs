namespace HomeServices.Shared.Options;

public class RedisOptions
{
    public const string SectionName = "RedisOptions";
    public string ConnectionString { get; set; } = string.Empty;
}
