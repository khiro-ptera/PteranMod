using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Projectiles
{
	public class CatalystDetonator : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 9;
			projectile.height = 9;
			projectile.damage = 25;
			projectile.scale = 1.5f;
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 480;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.light = 2;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;
			projectile.alpha = 0;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//target.immune[projectile.owner] = 7;
			//if (Main.rand.Next(3) < 1) target.AddBuff(mod.BuffType("Shocked"), 150);
		}
	}
}