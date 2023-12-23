using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Projectiles
{
	public class RadiantPulsarShot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 30;
			projectile.scale = 1.4f;
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 11;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 330;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.light = 2.8f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;
			projectile.alpha = 45;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 7;
		}
		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 120f && projectile.ai[0] < 270f)
			{
				projectile.scale += 0.005f * projectile.scale;
			}
			if (projectile.ai[0] == 120f || projectile.ai[0] == 270f)
			{
				projectile.width += 15;
				projectile.height += 15;
				projectile.damage += 14;
				projectile.knockBack += 1.6f;
				projectile.light += 0.5f;
			}
			if (projectile.ai[0] > 270f)
			{
				projectile.scale += 0.008f * projectile.scale;
				projectile.alpha += 2;
			}
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation += MathHelper.Pi;
			}
		}
	}
}