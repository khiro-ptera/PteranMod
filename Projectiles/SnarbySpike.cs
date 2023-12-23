﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace PteranMod.Projectiles
{
	public class SnarbySpike : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;              
			projectile.height = 45;
			projectile.scale = 1.5f;
			projectile.aiStyle = 1;             
			projectile.friendly = false;         //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
			projectile.melee = true;
			projectile.penetrate = -1;           
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.light = 2;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1; 
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			target.AddBuff(BuffID.Poisoned, 210);
			target.AddBuff(BuffID.Venom, 120);
			target.AddBuff(BuffID.Blackout, 20);
		}
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
	}
}