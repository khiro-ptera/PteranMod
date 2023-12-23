
using Terraria;
using Terraria.ModLoader;

namespace PteranMod.Dusts
{
	public class Catalyst : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1f;
		}

		public override bool Update(Dust dust)
		{
			dust.rotation += 0.1f;
			return false;
		}
	}
}