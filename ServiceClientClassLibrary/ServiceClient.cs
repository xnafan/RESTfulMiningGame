using RestSharp;
using ServiceClientClassLibrary.Model;
using System;

namespace ServiceClientClassLibrary
{
    public class ServiceClient
    {
        Random _rnd = new Random();
        RestClient _client;
        public Guid GameGuid { get; private set; }

        public ServiceClient(Uri baseUri, Guid gameGuid)
        {
            _client = new RestClient(baseUri);
            GameGuid = gameGuid;
        }


        public Game GetGameInfo()
        {
            return new AdminServiceClient(_client.BaseUrl).GetGameInfo(GameGuid);
        }
    }
}