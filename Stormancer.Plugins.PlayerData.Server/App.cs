using Stormancer;

namespace Stormancer.Server.PlayerData
{
    class App
    {
        public void Run(IAppBuilder builder)
        {
            builder.AddPlugin(new PlayerDataPlugin());
        }
    }
}
