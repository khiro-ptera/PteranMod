using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Projectiles
{
	class DruvasksJawbone : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 35;
			projectile.height = 35;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.magic = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 350;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
		}
		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] < 150f)
			{
				projectile.velocity *= 0.991f;
			}
			if (projectile.ai[0] > 150f)
			{
					projectile.velocity *= 1.009f;
			}
			if (projectile.ai[0] == 150f)
			{
				projectile.velocity *= -1;
			}
			projectile.rotation += 0.3f;
		}
		/*public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			projectile.Kill();
		}*/
	}
}
