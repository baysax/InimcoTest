using System.Text.Json.Serialization;

namespace InimcoTestBackend.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SocialAccountType
{
    Twitter,
    Facebook,
    Linkedin
}