using GenericDaoLibrary;
using System;

namespace MiningApi.Authentication;
public static class TokenAuthenticationTool
{
    private static readonly string SECRET = "!ø098yphoiaw4jh+";
    public const string HEADER_NAME = "team-authentication";
    public static bool ValidateToken (string token)
    {
        var components = token.Split(":");
        return (GenerateToken(components[0], components[1]).Equals(token));
    }

    public static string GenerateToken (string gameId, string teamId)
    {
        var combined = $"{gameId}:{teamId}";
        var saltedHash = (combined + SECRET).GetHashCode();
        var shortUidFromSaltedHash = ShortUIDTool.CreateShortId(6, saltedHash);
        return $"{combined}:{shortUidFromSaltedHash}";
    }

    public static (string GameId, string TeamId) Parse(string token)
    {
        var components = token.Split(":");
        return (components[0], components[1]);
    }
}