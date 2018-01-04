using Stormancer;
using Stormancer.Core;
using Stormancer.Plugins;

namespace Stormancer.Server.PlayerData
{
    class PlayerDataPlugin : IHostPlugin
    {
        internal const string METADATA_KEY = "stormancer.playerdata";

        public void Build(HostPluginBuildContext ctx)
        {
            ctx.SceneDependenciesRegistration += (IDependencyBuilder builder, ISceneHost scene) =>
            {
                if (scene.Metadata.ContainsKey(METADATA_KEY))
                {
                    builder.Register<PlayerDataService>().As<IPlayerDataService>().SingleInstance();
                    builder.Register<PlayerDataController>().InstancePerRequest();
                }
            };

            ctx.SceneCreated += (ISceneHost scene) =>
            {
                if (scene.Metadata.ContainsKey(METADATA_KEY))
                {
                    scene.AddController<PlayerDataController>();
                }
            };
        }
    }
}
