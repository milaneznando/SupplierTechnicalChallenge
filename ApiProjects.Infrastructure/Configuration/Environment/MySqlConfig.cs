namespace ApiProjects.Infrastructure.Configuration.Environment;

/// <summary>
/// Represents configuration settings for a MySQL database.
/// </summary>
/// <remarks>
/// This class is used to store and map MySQL-related configuration values,
/// such as the connection string, which can be retrieved from the application's configuration file.
/// </remarks>
public class MySqlConfig
{
    public string ConnectionString { get; set; }
}