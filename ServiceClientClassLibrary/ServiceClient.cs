using ServiceClientClassLibrary.Model;
using System;
namespace ServiceClientClassLibrary;
public class ServiceClient : ServiceClientBase
{
    public string GameGuid { get; private set; }

    public ServiceClient(Uri baseUri, string gameGuid) : base(baseUri) 
    {
        GameGuid = gameGuid;
    }

    public MiningGameDto GetGameInfo()
    {
        return new AdminServiceClient(_client.BaseUrl).GetGameInfo(GameGuid);
    }
}