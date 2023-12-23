using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs.Roarmulus;
using PteranMod.Buffs;

namespace PteranMod.Projectiles
{
	public class ShockBall : ModProjectile
	{
		//private int ai;
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.scale = 1.5f;
			projectile.aiStyle = 0;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 1500;
			projectile.light = 1;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.alpha = 40;
			//drawOffsetX = 20;
			//drawOriginOffsetY = 10;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("Shocked"), 120);
			projectile.Kill();
		}
	}
}