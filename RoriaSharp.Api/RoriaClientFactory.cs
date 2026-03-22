using System.Net.Http;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Abstractions.Authentication;
using RoriaSharp.Api.Generated;

namespace RoriaSharp.Api;

public static class RoriaClientFactory
{
    public static ApiClient Create(string baseUrl, HttpClient? httpClient = null)
    {
        // TODO: Pass token here
        var authProvider = new AnonymousAuthenticationProvider();
        
        // Initialize adapter
        var adapter = new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
        {
            BaseUrl = baseUrl
        };

        return new ApiClient(adapter);
    }
}