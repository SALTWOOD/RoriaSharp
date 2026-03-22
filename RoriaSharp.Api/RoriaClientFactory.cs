using System.Net.Http;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Abstractions.Authentication;
using RoriaSharp.Api.Generated;

namespace RoriaSharp.Api;

public static class RoriaClientFactory
{
    public static ApiClient Create(string baseUrl, Func<Task<string?>> tokenResolver, HttpClient? httpClient = null)
    {
        // Pass token here
        var tokenProvider = new RoriaTokenProvider(tokenResolver);
        
        // Initialize provider
        var authProvider = new BaseBearerTokenAuthenticationProvider(tokenProvider);
        
        // Initialize adapter
        var adapter = new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
        {
            BaseUrl = baseUrl
        };

        return new ApiClient(adapter);
    }
}