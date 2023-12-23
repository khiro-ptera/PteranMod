using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.NPCs.Snarbolax
{
	[AutoloadBossHead]
	public class SnarbyBell : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beast Bell");
		}
		public static bool bellDown = false;
		public override void SetDefaults()
		{
			npc.width = 20;
			npc.height = 40;
			npc.scale = 2.5f;
			//npc.boss = true;
			npc.knockBackResist = 0f;
			npc.aiStyle = 0;
			npc.damage = 0;
			npc.defense = 6;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.alpha = 0;
			bellDown = false;
			//npc.color = new Color(0, 80, 255, 100);
		}
		public override void AI()
		{
			bellDown = false;
		}
        /*public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
			bellDown = true;
		}
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
			bellDown = true;
		}*/
		public override bool CheckDead()
		{
            bellDown = true;
			//npc.dontTakeDamage = true;
			return true;
		}
	}
}