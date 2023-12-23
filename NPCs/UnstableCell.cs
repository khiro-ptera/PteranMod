using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.NPCs
{
	public class UnstableCell : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 32;
			npc.aiStyle = 85; 
			npc.damage = 40;
			npc.defense = 60;
			npc.lifeMax = 500;
			npc.HitSound = SoundID.NPCHit53;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.alpha = 100;
			//npc.color = new Color(0, 80, 255, 100);
			npc.value = 25f;
			npc.buffImmune[BuffID.Confused] = false; 
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.UndergroundMimic.Chance * 0.7f;
		}
		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.Glass, Main.rand.Next(3, 5));
			Item.NewItem(npc.getRect(), ItemID.BeamSword);
			if (Main.rand.Next(9) < 6)
            {
				Item.NewItem(npc.getRect(), mod.ItemType("EliteOrbOfAlchemy"), Main.rand.Next(1, 2));
			}
		}
	}
}