using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using System.Linq;

namespace HandModifier
{
    public class MQSPlugin : RocketPlugin<Configuration>
    {
		public static MQSPlugin Instance;

		protected override void Load()
		{
			MQSPlugin.Instance = this;

			UnturnedPlayerEvents.OnPlayerUpdateGesture += GestureChange;

			Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");
			Logger.LogWarning($"[{Name}] has been loaded! ");
			Logger.LogWarning("Dev: MQS#7816");
			Logger.LogWarning("Join this Discord for Support: https://discord.gg/Ssbpd9cvgp");
			Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");
		}

		private void GestureChange (UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
		{
			if (gesture == UnturnedPlayerEvents.PlayerGesture.InventoryOpen)
			{
				{
					if (player.GetPermissions().Any(x => x.Name == "modifier.ignore"))
                    {
						return;
                    }
					player.Inventory.items[2].resize(Configuration.Instance.Width, Configuration.Instance.Height);
				}
			}
		}

		protected override void Unload()
		{
			MQSPlugin.Instance = null;

			UnturnedPlayerEvents.OnPlayerUpdateGesture -= GestureChange;

			Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");
			Logger.LogWarning($"[{Name}] has been unloaded! ");
			Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");
		}
	}
}
