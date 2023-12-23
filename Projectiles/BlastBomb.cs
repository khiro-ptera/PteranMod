using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using PteranMod.Dusts;

namespace PteranMod.Projectiles
{
	public class BlastBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 2;
		}
		public override void SetDefaults()
		{
			projectile.scale = 1.1f;
			projectile.width = 0;
			projectile.height = 0;
			projectile.friendly = false;         
			projectile.hostile = false;         
			projectile.magic = true;           
			projectile.penetrate = -1;           
			projectile.timeLeft = 300;          
			projectile.light = 1.5f;            
			projectile.ignoreWater = true;          
			projectile.tileCollide = false;
			projectile.alpha = 0;
		}
		public override void AI()
		{
			projectile.ai[0]++;
			if(projectile.ai[0] == 1) projectile.rotation = Main.rand.Next(0, 360);
            if (projectile.ai[0] > 280)
			{
				projectile.alpha += 1;
				projectile.scale *= 1.05f;
				if (projectile.ai[0] % 4 == 0)
				{
					projectile.frame = 0;
				}
				else
				{
					projectile.frame = 1;
				}
			}
            else
            {
				if(projectile.ai[0] % 4 == 0)
				{
					projectile.frame = 1;
                }
                else
                {
					projectile.frame = 0;
				}
            }
            if(projectile.ai[0] == 299)
			{
				projectile.friendly = true;
				projectile.width = 80;
				projectile.height = 80;
			}
		}
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 30; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Spark>(), 0, 0);
			}
			Main.PlaySound(SoundID.Item14, projectile.position);
		}
	}
}