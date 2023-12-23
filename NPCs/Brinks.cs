using System;
using PteranMod.Dusts;
using PteranMod.Items;
using PteranMod.Items.Weapons;
using PteranMod.Items.Accessories;
using PteranMod;
using PteranMod.Items.Armor;
using PteranMod.Projectiles;
//using PteranMod.Tiles;
//using PteranMod.Walls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Brinks : ModNPC
	{
		public override string Texture => "PteranMod/NPCs/Brinks";
		public override bool Autoload(ref string name)
		{
			name = "BasicTokenMerchant";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackAverageChance[npc.type] = 0;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.scale = 1.6f;
			npc.damage = 10;
			npc.defense = 45;
			npc.lifeMax = 500;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.2f;
			animationType = NPCID.Guide;
		}

		/*public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Sparkle>());
			}
		}*/

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (PteranWorld.downedSnarby)
            {
				return true;
            }
			return false;
		}
		public override string TownNPCName()
		{
			return "Brinks";
		}
		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int stylist = NPC.FindFirstNPC(NPCID.Stylist);
			if (stylist >= 0 && Main.rand.NextBool(4))
			{
				return Main.npc[stylist].GivenName + "'s a solid stylist, but her skills are nothing compared to Bechamel's.";
			}
			switch (Main.rand.Next(4))
			{
				case 0:
					return "Got tokens? Trade 'em in for something more useful.";
				case 1:
					return "The Clockwork is rapidly evolving, it's scary.";
				case 2:
					return "What have I got for sale? Trinkets, odds and ends, that sort of thing.";
				default:
					return "Woah, you scared the mewcats outta me!";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemType<BristlingBuckler>());
			shop.item[nextSlot].shopCustomPrice = 2; 
			shop.item[nextSlot].shopSpecialCurrency = PteranMod.FangCustomCurrencyId;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<SnarbleBarb>());
			shop.item[nextSlot].shopCustomPrice = 2;
			shop.item[nextSlot].shopSpecialCurrency = PteranMod.FangCustomCurrencyId;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Antigua>());
			shop.item[nextSlot].shopCustomPrice = 5;
			shop.item[nextSlot].shopSpecialCurrency = PteranMod.FangCustomCurrencyId;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Pulsar>());
			shop.item[nextSlot].shopCustomPrice = 10;
			shop.item[nextSlot].shopSpecialCurrency = PteranMod.FangCustomCurrencyId;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Catalyzer>());
			shop.item[nextSlot].shopCustomPrice = 10;
			shop.item[nextSlot].shopSpecialCurrency = PteranMod.BarkCustomCurrencyId;
			nextSlot++;
			if (PteranWorld.downedRoar)
            {
				shop.item[nextSlot].SetDefaults(ItemType<Antigua>());
				shop.item[nextSlot].shopCustomPrice = 1;
				shop.item[nextSlot].shopSpecialCurrency = PteranMod.BarkCustomCurrencyId;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemType<Pulsar>());
				shop.item[nextSlot].shopCustomPrice = 2;
				shop.item[nextSlot].shopSpecialCurrency = PteranMod.BarkCustomCurrencyId;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemType<Catalyzer>());
				shop.item[nextSlot].shopCustomPrice = 2;
				shop.item[nextSlot].shopSpecialCurrency = PteranMod.BarkCustomCurrencyId;
				nextSlot++;
			}
		}

		public override void NPCLoot()
		{
			//Item.NewItem(npc.getRect(), ItemType<>());
		}
		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}
		/*
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileType<SparklingBall>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}*/
	}
}