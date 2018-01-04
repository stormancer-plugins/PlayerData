using MsgPack;

namespace Stormancer.Server.PlayerData
{
    public class PlayerDataUpdate
    {
        public string PlayerId;

        public MessagePackObject Data;
    }
}
