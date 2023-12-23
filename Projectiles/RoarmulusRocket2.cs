using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs.Roarmulus;
using PteranMod.Buffs;

namespace PteranMod.Projectiles
{
	public class RoarmulusRocket2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			projectile.Name = "Roarmulus Rocket";
		}
		//private int ai;
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 10;
			projectile.scale = 3.5f;
			projectile.aiStyle = 0;
			projectile.friendly = true;         
			projectile.hostile = true;      
			projectile.penetrate = 1;           
			projectile.timeLeft = 1500;          
			projectile.light = 1;            
			projectile.ignoreWater = true;          
			projectile.tileCollide = true;
			projectile.alpha = 0;
			drawOffsetX = 20;
			drawOriginOffsetY = 10;
		}
        /*public override bool? CanHitNPC(Projectile proj, NPC npc)
		{
			if (npc.type == NPC)
			{
				return true;
			}
			return null;

		}*/
        public override bool CanHitPlayer(Player target)
        {
			return true;
        }
        /*public override void AI()
		{
			ai++;
			if(ai > 300) 
			{
				projectile.hostile = false;
				projectile.friendly = true; 
			}
		}*/
        public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 210);
			target.AddBuff(mod.BuffType("Shocked"), 120);
			projectile.Kill();
		}
	}
}