using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BloodyTakao.BloodysServerGuard
{
    public class ChatControlModule
    {
		public static async Task ControllMessageAsync(SocketMessage message)
		{
			if (message.Author.IsBot || message.Author.IsWebhook || message is ISystemMessage || message.Channel is SocketDMChannel)
			{
				return;
			}

			foreach (string word in wordBlacklist)
			{
				if (message.Content.ToLower().Contains(word))
				{
					await message.Channel.SendMessageAsync($"{message.Author.Mention} No swearing allowed here!");
					await message.DeleteAsync();
				}
			}
		}

		public static List<string> wordBlacklist { get; set; } = new List<string>
		{
			"fuck",
			"shit",
			"faggot",
		};
    }
}
