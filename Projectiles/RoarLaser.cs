using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs.Roarmulus;
using PteranMod.Buffs;
using System;

namespace PteranMod.Projectiles
{
	public class RoarLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			projectile.Name = "Ironclaw Beam MK2";
		}
		//private int ai;
		public override void SetDefaults()
		{
			projectile.width = 50;
			projectile.height = 50;
			projectile.scale = 1.5f;
			projectile.aiStyle = 0;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 300;
			projectile.light = 1;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.alpha = 0;
			//drawOffsetX = 20;
			//drawOriginOffsetY = 10;
		}
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("Shocked"), 180);
		}
	}
}