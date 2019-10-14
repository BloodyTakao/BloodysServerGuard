using System;
using System.Threading.Tasks;
using Nodsoft.YumeChan.PluginBase;

namespace BloodyTakao.BloodysServerGuard
{
    class PluginProperties : IPlugin
    {
        public Version PluginVersion { get; } = typeof(PluginProperties).Assembly.GetName().Version;

        public string PluginDisplayName { get; } = "Bloody's Server Guard";

        public bool PluginStealth { get; } = false;

        public bool PluginLoaded { get; internal set; }

        public Task LoadPlugin()
        {
            PluginLoaded = true;
            return Task.CompletedTask;
        }

        public Task UnloadPlugin()
        {
            PluginLoaded = false;
            return Task.CompletedTask;
        }
    }
}
