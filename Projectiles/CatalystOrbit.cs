using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Projectiles
{
    public class CatalystOrbit : ModProjectile
	{
		private NPC closest;
		private float distance = 20 * 16;
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 2;
		}
		public override void SetDefaults()
		{
			projectile.width = 0;
			projectile.height = 0;
			projectile.scale = 1f;
			projectile.friendly = false;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 100000;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.light = 0.2f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;
			projectile.alpha = 25; 
			//closest = Main.npc.Where(n => n.active && n.DistanceSQ(projectile.Center) < distance * distance).OrderBy(n => n.DistanceSQ(projectile.Center)).FirstOrDefault();
		}
		/*public override void AI()
		{
			int orbitSpeed = 4;
			int degInc = 1;
			int dist = 64;
			float newDeg = projectile.localAI[0] * orbitSpeed;
			float rad = MathHelper.ToRadians(newDeg); //Convert degrees to radians

			projectile.position.X = closest.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
			projectile.position.Y = closest.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

			projectile.localAI[0] += degInc * orbitSpeed;
			if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}
		}*/
	}
}
