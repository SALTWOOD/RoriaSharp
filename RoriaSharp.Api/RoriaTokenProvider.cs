using Microsoft.Kiota.Abstractions.Authentication;

namespace RoriaSharp.Api;

public class RoriaTokenProvider : IAccessTokenProvider
{
    private readonly Func<Task<string?>> _tokenResolver;

    public RoriaTokenProvider(Func<Task<string?>> tokenResolver)
    {
        _tokenResolver = tokenResolver;
    }

    public async Task<string> GetAuthorizationTokenAsync(
        Uri uri, 
        Dictionary<string, object>? additionalAuthenticationContext = default, 
        CancellationToken cancellationToken = default)
    {
        var token = await _tokenResolver();
        
        return token ?? string.Empty;
    }

    public AllowedHostsValidator AllowedHostsValidator { get; } = new();
}