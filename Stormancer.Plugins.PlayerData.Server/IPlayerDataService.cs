using MsgPack;

namespace Stormancer.Server.PlayerData
{
    interface IPlayerDataService
    {
        void SetPlayerData(string id, MessagePackObject data);

        MessagePackObject GetPlayerData(string id);
    }
}
