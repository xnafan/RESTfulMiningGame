using RestSharp;
using ServiceClientClassLibrary.Model;
using System;

namespace ServiceClientClassLibrary
{
    public class AdminServiceClient : ServiceClientBase
    {
        public AdminServiceClient(Uri baseUri) : base(baseUri){}

        public string CreateGame(string gameName, int mapSideLength)
        {
            var request = CreateRequest("games");
            request.AddJsonBody(new MiningGameDto() { Name = gameName, MapSideLength = mapSideLength});
            var result = _client.Post<string>(request);
            if (result.IsSuccessful)
            {
                return result.Data;
            }
            else
            {
                throw new Exception($"Error creating new Game. Error was '{result.ErrorMessage}'");
            }
        }

        public bool DeleteGame(string gameId)
        {
            var request = CreateRequest($"games/{gameId}");
            var result = _client.Delete<bool>(request);
            if (result.IsSuccessful)
            {
                return result.Data;
            }
            else
            {
                throw new Exception($"Error deleting game '{gameId}'. Error was '{result.ErrorMessage}'");
            }
        }

        public bool DoesGameExist(string gameId)
        {
            return GetGameInfo(gameId) != null;
        }

        public MiningGameDto GetGameInfo(string gameId)
        {
            string relativePath = $"games/{gameId}";
            var result = _client.Get<MiningGameDto>(CreateRequest(relativePath));
            if (result.IsSuccessful)
            {
                return result.Data;
            }
            throw new Exception($"Unable to retrieve Game info from server using{_client.BaseUrl + "/" + relativePath}. Error was '{result.ErrorMessage}'");
        }
    }
}