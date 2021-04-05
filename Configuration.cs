using Rocket.API;

namespace HandModifier
{
	public class Configuration : IRocketPluginConfiguration
	{
		public byte Width;
		public byte Height;


		public void LoadDefaults()
		{
			Width = 0;
			Height = 0;
		}
	}
}