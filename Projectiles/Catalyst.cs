using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Projectiles
{
	internal class Catalyst : ModProjectile
	{
		private bool attached;
		public NPC center;
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 2;
		}
		public override void SetDefaults()
		{
			attached = false;
			projectile.width = 9;
			projectile.height = 9;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1; 
			projectile.timeLeft = 480;
			projectile.alpha = 0;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.friendly = false;
			attached = true;
			projectile.timeLeft = 100000;
			//center = target;
			projectile.penetrate = -1;
			center = target;
			target.AddBuff(mod.BuffType("Catalyzed"), 100000); 
			//Projectile.NewProjectile(projectile.position, projectile.velocity, mod.ProjectileType("CatalystOrbit"), 0, 0);
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}
            if (attached)
			{
				int orbitSpeed = 1;
				int degInc = 1;
				int dist = 30;
				float newDeg = projectile.localAI[0] * orbitSpeed;
				float rad = MathHelper.ToRadians(newDeg); //Convert degrees to radians

				projectile.position.X = center.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
				projectile.position.Y = center.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

				projectile.localAI[0] += degInc * orbitSpeed;
                if (!center.HasBuff(mod.BuffType("Catalyzed")))
				{
					projectile.timeLeft = 0;
				}
			}
		}
	}
}