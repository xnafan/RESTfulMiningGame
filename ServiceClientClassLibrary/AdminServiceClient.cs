using RestSharp;
using ServiceClientClassLibrary.Model;
using System;

namespace ServiceClientClassLibrary
{
    public class AdminServiceClient
    {
        Random _rnd = new Random();
        RestClient _client;

        public AdminServiceClient(Uri baseUri)
        {
            _client = new RestClient(baseUri);
        }

        public Guid CreateGame(string gameName, int gameAreaWidthInQuadrants, int gameAreaHeightInQuadrants, int seed = 0)
        {
            var request = new RestRequest("games");
            request.AddJsonBody(new Game() { Name = gameName, GameAreaWidthInQuadrants = gameAreaWidthInQuadrants, GameAreaHeightInQuadrants = gameAreaHeightInQuadrants, Seed = (seed== 0 ? _rnd.Next(1000000):seed)});
            var result = _client.Post<Guid>(request);
            if (result.IsSuccessful)
            {
                return result.Data;
            }
            else
            {
                throw new Exception($"Error creating new game. Error was '{result.ErrorMessage}'");
            }
        }

        public bool DeleteGame(Guid gameGuid)
        {
            var request = new RestRequest("games/{gameGuid}");
            var result = _client.Delete<bool>(request);
            if (result.IsSuccessful)
            {
                return result.Data;
            }
            else
            {
                throw new Exception($"Error deleting game '{gameGuid}'. Error was '{result.ErrorMessage}'");
            }
        }

        public bool IsGameRunning(Guid gameGuid)
        {
            return GetGameInfo(gameGuid) != null;
        }

        public Game GetGameInfo(Guid gameGuid)
        {
            string relativePath = $"games/{gameGuid}";
            var result = _client.Get<Game>(new RestRequest(relativePath));
            if (result.IsSuccessful)
            {
                return result.Data;
            }
            throw new Exception($"Unable to retrieve Game info from server using{_client.BaseUrl + "/" + relativePath}. Error was '{result.ErrorMessage}'");
        }
    }
}