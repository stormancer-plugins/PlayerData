using System.Collections.Concurrent;
using Stormancer.Core;
using Stormancer;
using MsgPack;

namespace Stormancer.Server.PlayerData
{
    class PlayerDataService : IPlayerDataService
    {
        private readonly ISceneHost _scene;

        private ConcurrentDictionary<string, MessagePackObject> _playerData = new ConcurrentDictionary<string, MessagePackObject>();

        private const string PLAYERDATA_UPDATED_ROUTE = "playerdata.updated";

        public PlayerDataService(ISceneHost scene)
        {
            _scene = scene;
        }

        public MessagePackObject GetPlayerData(string id)
        {
            MessagePackObject data;
            if (_playerData.TryGetValue(id, out data))
            {
                return data;
            }
            else
            {
                return new MessagePackObject();
            }
        }

        public void SetPlayerData(string id, MessagePackObject data)
        {
            _playerData[id] = data;

            _scene.Broadcast(PLAYERDATA_UPDATED_ROUTE,
                new PlayerDataUpdate { PlayerId = id, Data = data },
                PacketPriority.LOW_PRIORITY,
                PacketReliability.RELIABLE_ORDERED
                );
        }
    }
}
