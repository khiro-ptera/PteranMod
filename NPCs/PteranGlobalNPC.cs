using PteranMod.Projectiles;
using PteranMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.NPCs
{
	class PteranGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public bool shocked;
		public bool hemorrhage;
		public int hemorrhageCounter;
		public bool catalyzed;
		public int catalyzeCounter;

		public override void ResetEffects(NPC npc)
		{
			shocked = false;
			hemorrhage = false;
			catalyzed = false;
		}
        public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (shocked)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 20;
				if (damage < 2)
				{
					damage = 2;
				}
				npc.defense = (int)(npc.defense * 0.8);
			}
            if (hemorrhage)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= (int)(6 * (1 + hemorrhageCounter * 0.6));
				if (damage < 2)
				{
					damage = 2;
				}
            }
            else
            {
				hemorrhageCounter = 0;
            }
		}
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.type == ProjectileType<DecimateAxe>() && hemorrhageCounter < 5)
            {
				hemorrhageCounter++;
			}
			if (projectile.type == ProjectileType<Projectiles.Catalyst>() && catalyzeCounter < 10)
			{
				catalyzeCounter++;
			}
			if (projectile.type == ProjectileType<CatalystDetonator>())
			{
				//npc.life -= catalyzeCounter * 10;
				//catalyzeCounter = 0;
			}
		}

		/*public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (catalyzed)
			{
				int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustType<Dusts.Catalyst>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
				if (catalyzeCounter == 0) Main.dust[dust].scale = 0;
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}*/
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.type == ProjectileType<CatalystDetonator>())
			{
				if (catalyzeCounter > 0)
				{
					damage = (int)(damage * 1.32f * (catalyzeCounter*(1 + 0.15f * catalyzeCounter) + 1));
					knockback += catalyzeCounter * 2.5f;
					catalyzeCounter = 0;
					if(npc.HasBuff(mod.BuffType("Catalyzed"))) npc.DelBuff(npc.FindBuffIndex(mod.BuffType("Catalyzed")));
				}
				//else damage = 25;
			}
			if (projectile.type == ProjectileType<Projectiles.Catalyst>())
			{
				damage = 1;
			}
		}
        public override void NPCLoot(NPC npc)
		{
			if ((npc.type == NPCID.Zombie) || (npc.type == NPCID.BlueSlime) || (npc.type == NPCID.ArmedZombie))
            {
				if (Main.rand.Next(25) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("SimpleOrbOfAlchemy"), Main.rand.Next(1, 2));
				}
			}
			if (npc.type == NPCID.DarkCaster)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("SimpleOrbOfAlchemy"), 1);
			}
			if (npc.type == NPCID.Tim)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("AdvancedOrbOfAlchemy"), Main.rand.Next(1, 4));
			}
			if (npc.type == NPCID.Demon)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("SimpleOrbOfAlchemy"), 1);
				if (Main.rand.Next(10) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("AdvancedOrbOfAlchemy"), Main.rand.Next(1, 2));
				}
			}
			if (npc.type == NPCID.Hellbat)
			{
				if (Main.rand.Next(24) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("AdvancedOrbOfAlchemy"), Main.rand.Next(1, 2));
				}
			}
			if (npc.type == NPCID.LavaSlime)
			{
				if (Main.rand.Next(25) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("AdvancedOrbOfAlchemy"), Main.rand.Next(1, 2));
				}
			}
			if ((npc.type == NPCID.Mimic) || (npc.type == NPCID.BigMimicHallow) || (npc.type == NPCID.BigMimicCorruption) || (npc.type == NPCID.BigMimicCrimson))
			{
				Item.NewItem(npc.getRect(), mod.ItemType("AdvancedOrbOfAlchemy"), 1);
				if (Main.rand.Next(2) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("EliteOrbOfAlchemy"), 1);
				}
			}
			if ((npc.type == NPCID.PossessedArmor) || (npc.type == NPCID.Wraith) || (npc.type == NPCID.Werewolf) || (npc.type == NPCID.WanderingEye))
			{
				if (Main.rand.Next(15) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("AdvancedOrbOfAlchemy"), 1);
				}
				if (Main.rand.Next(50) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("EliteOrbOfAlchemy"), 1);
				}
			}
			if ((npc.type == NPCID.TacticalSkeleton) || (npc.type == NPCID.SkeletonSniper) 
				|| (npc.type == NPCID.SkeletonCommando) || (npc.type == NPCID.BoneLee)
				|| (npc.type == NPCID.Paladin))
			{
				Item.NewItem(npc.getRect(), mod.ItemType("EliteOrbOfAlchemy"), 1);
				if (Main.rand.Next(5) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("EternalOrbOfAlchemy"), 1);
				}
			}
			if ((npc.type == NPCID.Wolf))
			{
				if (Main.rand.Next(20) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("Striker"), 1);
				}
				if (Main.rand.Next(12) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("AdvancedOrbOfAlchemy"), 1);
				}
				if (Main.rand.Next(36) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("EliteOrbOfAlchemy"), 1);
				}
			}
			if ((npc.type == NPCID.DD2OgreT3))
			{
				if (Main.rand.Next(8) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("DruvasksJawbone"), 1);
				}
			}
			if ((npc.type == NPCID.SkeletronPrime))
			{
				if (Main.rand.Next(50) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("Decimate"), 1);
				}
			}
			if ((npc.type == NPCID.CultistBoss))
			{
				if (Main.rand.Next(50) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("VoidFission"), 1);
				}
			}
			if ((npc.type == NPCID.DungeonSpirit))
			{
				if (Main.rand.Next(100) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("SpiritSmash"), 1);
				}
			}
			if ((npc.type == NPCID.CursedSkull))
			{
				if (Main.rand.Next(25) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("SpiritArc"), 1);
				}
			}
			if ((npc.type == NPCID.KingSlime))
			{
				if (Main.rand.Next(5) < 1)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("SlimeWaif"), 1);
				}
			}
		}
	}
}
