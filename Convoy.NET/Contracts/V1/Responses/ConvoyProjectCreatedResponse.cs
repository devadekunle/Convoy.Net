using System.Text.Json.Serialization;

namespace Convoy.NET.Contracts.V1.Responses;

public class ConvoyProjectCreatedResponse : BaseResponse
{
    [JsonPropertyName("api_key")]
    public ApiKey ApiKey { get; set; }

    [JsonPropertyName("project")]
    public Project Project { get; set; }
}

public class ApiKey
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("role")]
    public Role Role { get; set; }

    [JsonPropertyName("key_type")]
    public string KeyType { get; set; }

    [JsonPropertyName("expires_at")]
    public DateTime ExpiresAt { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
}

public class Role
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("project")]
    public string Project { get; set; }
}

public class Project
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("logo_url")]
    public string LogoUrl { get; set; }

    [JsonPropertyName("organisation_id")]
    public string OrganisationId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("config")]
    public Config Config { get; set; }

    [JsonPropertyName("statistics")]
    public object Statistics { get; set; }

    [JsonPropertyName("retained_events")]
    public int RetainedEvents { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonPropertyName("deleted_at")]
    public object DeletedAt { get; set; }
}

public class Config
{
    [JsonPropertyName("max_payload_read_size")]
    public int MaxPayloadReadSize { get; set; }

    [JsonPropertyName("replay_attacks_prevention_enabled")]
    public bool ReplayAttacksPreventionEnabled { get; set; }

    [JsonPropertyName("retention_policy_enabled")]
    public bool RetentionPolicyEnabled { get; set; }

    [JsonPropertyName("disable_endpoint")]
    public bool DisableEndpoint { get; set; }

    [JsonPropertyName("retention_policy")]
    public RetentionPolicy RetentionPolicy { get; set; }

    [JsonPropertyName("ratelimit")]
    public Ratelimit RateLimit { get; set; }

    [JsonPropertyName("strategy")]
    public Strategy Strategy { get; set; }

    [JsonPropertyName("signature")]
    public Signature Signature { get; set; }

    [JsonPropertyName("meta_event")]
    public MetaEvent MetaEvent { get; set; }
}

public class RetentionPolicy
{
    [JsonPropertyName("policy")]
    public string Policy { get; set; }
}

public class Ratelimit
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}

public class Strategy
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    [JsonPropertyName("retry_count")]
    public int RetryCount { get; set; }
}

public class Signature
{
    public string Header { get; set; }
    public Version[] Versions { get; set; }
}

public class Version
{
    public string Uid { get; set; }
    public string Hash { get; set; }
    public string Encoding { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
}

public class MetaEvent
{
    [JsonPropertyName("is_enabled")]
    public bool IsEnabled { get; set; }

    public string Type { get; set; }

    [JsonPropertyName("event_type")]
    public object EventType { get; set; }

    public string Url { get; set; }
    public string Secret { get; set; }
    public object PubSub { get; set; }
}