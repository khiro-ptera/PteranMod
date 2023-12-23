using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace PteranMod.Projectiles
{
	public class DecimateAxe : ModProjectile
	{
		// The folder path to the flail chain sprite
		private const string ChainTexturePath = "PteranMod/Projectiles/DecimateHandle";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decimate Axe"); // Set the projectile name to Example Flail Ball
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 25;
			projectile.scale = 1.6f;
			projectile.timeLeft = 30;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.penetrate = -1; // Make the flail infinitely penetrate like other flails
			projectile.melee = true;
			//	projectile.aiStyle = 15; // The vanilla flails all use aiStyle 15, but we must not use it since we want to customize the range and behavior.
		}

		// This AI code is adapted from the aiStyle 15. We need to re-implement this to customize the behavior of our flail
		public override void AI()
		{
			projectile.ai[0]++;
			var player = Main.player[projectile.owner];

			// If owner player dies, remove the flail.
			if (player.dead)
			{
				projectile.Kill();
				return;
			}

			// This prevents the item from being able to be used again prior to this projectile dying
			player.itemAnimation = 10;
			player.itemTime = 10;

			// Here we turn the player and projectile based on the relative positioning of the player and projectile.
			int newDirection = projectile.Center.X > player.Center.X ? 1 : -1;
			player.ChangeDir(newDirection);
			projectile.direction = newDirection;

			var vectorToPlayer = player.MountedCenter - projectile.Center;
			float currentChainLength = vectorToPlayer.Length();
			if (currentChainLength > 40)
            {
				if (projectile.ai[0] > 6)
				{
					projectile.velocity.X *= -1;
					projectile.ai[0] = 0;
				}
            }
			projectile.velocity.Y = 0;
			projectile.position.Y = player.position.Y;
            if (projectile.position.X - player.position.X > 41)
            {
				projectile.position.X = player.position.X + 40;
			}
			if (projectile.position.X - player.position.X < -41)
			{
				projectile.position.X = player.position.X - 40;
			}
			//projectile.ai[1]++;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			var player = Main.player[projectile.owner];

			Vector2 mountedCenter = player.MountedCenter;
			Texture2D chainTexture = ModContent.GetTexture(ChainTexturePath);

			var drawPosition = projectile.Center;
			var remainingVectorToPlayer = mountedCenter - drawPosition;

			float rotation = remainingVectorToPlayer.ToRotation() - MathHelper.PiOver2;

			if (projectile.alpha == 0)
			{
				int direction = -1;

				if (projectile.Center.X < mountedCenter.X)
					direction = 1;

				player.itemRotation = (float)Math.Atan2(remainingVectorToPlayer.Y * direction, remainingVectorToPlayer.X * direction);
			}

			// This while loop draws the chain texture from the projectile to the player, looping to draw the chain texture along the path
			while (true)
			{
				float length = remainingVectorToPlayer.Length();

				// Once the remaining length is small enough, we terminate the loop
				if (length < 25f || float.IsNaN(length))
					break;

				// drawPosition is advanced along the vector back to the player by 12 pixels
				// 12 comes from the height of ExampleFlailProjectileChain.png and the spacing that we desired between links
				drawPosition += remainingVectorToPlayer * 12 / length;
				remainingVectorToPlayer = mountedCenter - drawPosition;

				// Finally, we draw the texture at the coordinates using the lighting information of the tile coordinates of the chain section
				Color color = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
				spriteBatch.Draw(chainTexture, drawPosition - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
			}

			return true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.player[projectile.owner].statLife += damage/30;
			Main.player[projectile.owner].HealEffect(damage/30, true);
			target.AddBuff(mod.BuffType("Hemorrhage"), 180);
		}
	}
}