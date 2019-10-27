using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

using static System.IO.Path;

namespace BloodyTakao.BloodysServerGuard
{
	public static class ChatControlModule
	{
		public static List<string> WordBlacklist { get; set; } = new List<string>();

		public static DirectoryInfo BlacklistLocation { get; set; } 
			= Directory.CreateDirectory(Directory.GetCurrentDirectory() + DirectorySeparatorChar 
			+ "Config" + DirectorySeparatorChar + typeof(PluginProperties).Assembly.GetName().Name);

		public static FileInfo BlacklistFileInfo { get; set; } = new FileInfo(BlacklistLocation.FullName + DirectorySeparatorChar + "blacklist.list");

		public static async Task ControllMessageAsync(SocketMessage message)
		{
			if (message.Author.IsBot || message.Author.IsWebhook || message is ISystemMessage || message.Channel is SocketDMChannel)
			{
				return;
			}

			foreach (string word in WordBlacklist)
			{
				if (message.Content.ToLower().Contains(word))
				{
					await message.Channel.SendMessageAsync($"{message.Author.Mention} No swearing allowed here!");
					await message.DeleteAsync();
				}
			}
		}

		public static async Task InitBlacklistAsync()
		{
			if (!BlacklistFileInfo.Exists)
			{
				BlacklistFileInfo.Create().Close();
				WordBlacklist = new List<string>(); // Assign empty list instead of null, to prevent WordBlacklist property from reading the file indefinitely.
				return;
			}

			WordBlacklist = new List<string>(await File.ReadAllLinesAsync(BlacklistFileInfo.FullName));

		}
	}
}
