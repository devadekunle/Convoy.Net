using Convoy.NET.Contracts.V1.Enums;
using System.Text.Json.Serialization;

namespace Convoy.NET.Contracts.V1.Requests;

public class CreateProject
{
    public Config Config { get; set; }

    [JsonPropertyName("logo_url")]
    public string LogoUrl { get; set; }

    public string Name { get; set; }
    public ProjectType Type { get; set; }
}

public class Config
{
    [JsonPropertyName("disable_endpoint")]
    public bool DisableEndpoint { get; set; }

    [JsonPropertyName("max_payload_read_size")]
    public int MaxPayloadReadSize { get; set; }

    [JsonPropertyName("meta_event")]
    public MetaEvent MetaEvent { get; set; }

    public Ratelimit RateLimit { get; set; }

    [JsonPropertyName("replay_attacks_prevention_enabled")]
    public bool ReplayAttacksPreventionEnabled { get; set; }

    [JsonPropertyName("retention_policy")]
    public RetentionPolicy RetentionPolicy { get; set; }

    [JsonPropertyName("retention_policy_enabled")]
    public bool RetentionPolicyEnabled { get; set; }

    public Signature Signature { get; set; }
    public Strategy Strategy { get; set; }
}

public class MetaEvent
{
    [JsonPropertyName("event_type")]
    public string[] EventType { get; set; }

    [JsonPropertyName("is_enabled")]
    public bool IsEnabled { get; set; }

    public string Secret { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
}

public class Ratelimit
{
    public int Count { get; set; }
    public int Duration { get; set; }
}

public class RetentionPolicy
{
    public string Policy { get; set; }
}

public class Signature
{
    public string Header { get; set; }
    public Version[] Versions { get; set; }
}

public class Version
{
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    public string Encoding { get; set; }
    public string Hash { get; set; }
    public string Uid { get; set; }
}

public class Strategy
{
    public int Duration { get; set; }

    [JsonPropertyName("retry_count")]
    public int RetryCount { get; set; }

    public string Type { get; set; }
}