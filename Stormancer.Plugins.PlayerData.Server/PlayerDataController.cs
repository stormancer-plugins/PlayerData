using MsgPack;
using Stormancer.Server.API;
using Stormancer.Server.Users;
using Stormancer;
using Stormancer.Diagnostics;
using Stormancer.Plugins;
using System.Threading.Tasks;

namespace Stormancer.Server.PlayerData
{
    class PlayerDataController : ControllerBase
    {
        private readonly IPlayerDataService _service;
        private readonly ILogger _logger;
        private readonly IUserSessions _sessions;

        public PlayerDataController(IPlayerDataService service,
            ILogger logger,
            IUserSessions sessions)
        {
            _service = service;
            _logger = logger;
            _sessions = sessions;
        }

        public async Task SetPlayerData(RequestContext<IScenePeerClient> ctx)
        {
            var player = await _sessions.GetUser(ctx.RemotePeer);
            var data = ctx.ReadObject<MessagePackObject>();
            if (player == null)
            {
                throw new ClientException("Player not authenticated.");
            }
            _service.SetPlayerData(player.Id, data);
        }

        public Task GetPlayerData(RequestContext<IScenePeerClient> ctx)
        {
            var playerId = ctx.ReadObject<string>();

            ctx.SendValue(_service.GetPlayerData(playerId));
            return Task.CompletedTask;
        }
    }
}
