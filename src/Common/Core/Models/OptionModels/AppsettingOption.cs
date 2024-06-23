namespace Core.Models.OptionModels;

public class AppsettingOption
{
    public const string SectionName = "Settings";

    public required AppsettingElasticOptionModel Elastic { get; init; }
    public required AppsettingMongoOptionModel Mongo { get; init; }
    public required AppsettingPostgreOptionModel Postgres { get; init; }
    public required AppsettingRabbitMqOptionModel RabbitMq { get; init; }
    public required string JwtKey { get; init; }
}

public class AppsettingElasticOptionModel
{
    public required string ProjectName { get; set; }
    public required string ElasticUri { get; set; }
    public required string Environment { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class AppsettingMongoOptionModel
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string Host { get; init; }
    public required int Port { get; init; }
    public required string DatabaseName { get; init; }

    public string ConnectionString => $"mongodb://{Username}:{Password}@{Host}:{Port}/{DatabaseName}?authSource=admin";
}

public class AppsettingPostgreOptionModel
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string Host { get; init; }
    public required int Port { get; init; }
    public required string DatabaseName { get; init; }

    public string ConnectionString => $"Host={Host};Port={Port};Database={DatabaseName};Username={Username};Password={Password}";
}

public class AppsettingRabbitMqOptionModel
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string Host { get; init; }
    public required int Port { get; init; }
}
