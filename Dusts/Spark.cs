
using Terraria;
using Terraria.ModLoader;

namespace PteranMod.Dusts
{
	public class Spark : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.6f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.5f;
		}

		public override bool Update(Dust dust)
		{
			dust.velocity *= 1.05f;
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale *= 0.99f;
			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, light, light, light);
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}