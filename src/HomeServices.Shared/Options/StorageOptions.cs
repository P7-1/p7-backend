namespace HomeServices.Shared.Options;

public class StorageOptions
{
    public const string SectionName = "StorageOptions";
    public string ConnectionString { get; set; } = string.Empty;
    public string ContainerName { get; set; } = string.Empty;
}
