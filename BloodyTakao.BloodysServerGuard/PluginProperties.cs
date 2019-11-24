using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Nodsoft.YumeChan.PluginBase;

namespace BloodyTakao.BloodysServerGuard
{
    public class PluginProperties : Plugin, IMessageTap
    {        
        public override string PluginDisplayName { get; } = "Bloody's Server Guard";

        public override bool PluginStealth { get; } = false;

        public override async Task LoadPlugin()
        {
			await base.LoadPlugin();
        }
		public override async Task UnloadPlugin()
		{
			await base.UnloadPlugin();
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
