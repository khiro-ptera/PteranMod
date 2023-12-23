using PteranMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using PteranMod.Items.Weapons;

namespace PteranMod
{
	public class PteranPlayer : ModPlayer
	{
		public bool shocked;
		public bool bristling;
		public bool appled;
		public bool what;
		public bool slimePet;
		public override void ResetEffects()
		{
			shocked = false;
			bristling = false;
			what = false;
			appled = false;
			slimePet = false;
		}

		public override void UpdateBadLifeRegen()
		{
			if (shocked)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
				player.lifeRegen -= 24;
			}
		}

		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ItemType<ProtoSword>());
			items.Add(item);
			Item item2 = new Item();
			item2.SetDefaults(ItemType<ProtoGun>());
			items.Add(item2);
			Item item3 = new Item();
			item3.SetDefaults(ItemID.MusketBall);
			item3.stack = 100;
			items.Add(item3);
		}
		/*public override void OnHitAnything(float x, float y, Entity victim)
        {
            base.OnHitAnything(x, y, victim);
        }*/
		public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
		{
			if (bristling)
            {
				player.thorns = 0.5f;
			}
			if (appled)
			{
				if(player.statLife % 150 == 0 && player.statLife >= 0 && player.statLife < player.statLifeMax2)
                {
					player.statLife += 200;
                }
			}
			if (what)
			{
				int randBuff = Main.rand.Next(205);
				player.AddBuff(randBuff, Main.rand.Next(600));
			}
		}
	}
}
