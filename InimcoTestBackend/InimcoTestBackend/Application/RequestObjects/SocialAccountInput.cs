using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application.RequestObjects;

public record SocialAccountInput(SocialAccountType Type, string? Address);