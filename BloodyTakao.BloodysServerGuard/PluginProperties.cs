using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Nodsoft.YumeChan.PluginBase;

namespace BloodyTakao.BloodysServerGuard
{
    public class PluginProperties : IPlugin, IMessageTap
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

		public Task OnMessageDeleted(Cacheable<IMessage, ulong> message, ISocketMessageChannel channel)
		{
			return Task.CompletedTask;
		}

		public async Task OnMessageReceived(SocketMessage message)
		{
			await ChatControlModule.ControllMessageAsync(message).ConfigureAwait(false);
		}

		public Task OnMessageUpdated(Cacheable<IMessage, ulong> messageBeforeUpdate, SocketMessage messageAfterUpdate, ISocketMessageChannel channel)
		{
			return Task.CompletedTask;
		}
			
    }
}
