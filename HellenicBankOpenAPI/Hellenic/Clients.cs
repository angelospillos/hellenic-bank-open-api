using System.Text;
using HellenicBankOpenAPI.Models;
using Refit;

namespace HellenicBankOpenAPI.Hellenic;

public static class Clients
{
    public static readonly string LiveAuthEndpoint = "https://oauthprod.hellenicbank.com";
    public static readonly string SandboxAuthEndpoint = "https://sandbox-oauth.hellenicbank.com";

    public static readonly string SandboxEndpoint = "https://sandbox-apis.hellenicbank.com";
    public static readonly string LiveEndpoint = "https://apisprod.hellenicbank.com/";

    public static IHellenicClient CreateHellenicClient(string url)
    {
        //Enables Logging of Http Requests
        var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(url) };
        return RestService.For<IHellenicClient>(httpClient);
    }

    public static ITokenClient CreateTokenClient(string url)
    {
        //Enables Logging of Http Requests
        var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(url) };
        return RestService.For<ITokenClient>(httpClient);
    }

    public static string CreateBasicAuth(AppSettings settings)
    {
        var credentials = $"{settings.ClientId}:{settings.ClientSecret}";
        var payload = Encoding.UTF8.GetBytes(credentials);
        return $"Basic {Convert.ToBase64String(payload)}";
    }
}
