using Stormancer.Core;

namespace Stormancer.Server.PlayerData
{
    public static class PlayerDataExtensions
    {
        public static void AddPlayerData(this ISceneHost host)
        {
            host.Metadata[PlayerDataPlugin.METADATA_KEY] = "enabled";
        }
    }
}
