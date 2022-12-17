using RestSharp;
using System;

namespace ServiceClientClassLibrary;
public abstract class ServiceClientBase
{
    public static string ApiAuthenticationHeaderName { get => "Client-Authentication-Key"; }
    public static string ApiAuthenticationHeaderValue { get => "46F9FB60-9D7E-4B27-85A4-02E22960FF2A"; }

    protected readonly RestClient _client;

    public ServiceClientBase(Uri baseUri) => _client = new RestClient(baseUri);

    internal IRestRequest CreateRequest(string relativeUrl)
    {
        return new RestRequest(relativeUrl).AddHeader(ApiAuthenticationHeaderName, ApiAuthenticationHeaderValue);
    }
}