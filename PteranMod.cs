using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using PteranMod.Items;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace PteranMod
{
	public class PteranMod : Mod
	{
		public static int FangCustomCurrencyId;
		public static int BarkCustomCurrencyId;

		public override void Load()
		{
			FangCustomCurrencyId = CustomCurrencyManager.RegisterCurrency(new SnarbyToken(ModContent.ItemType<Items.FrumiousFang>(), 999L));
			BarkCustomCurrencyId = CustomCurrencyManager.RegisterCurrency(new RoarToken(ModContent.ItemType<Items.BarkModule>(), 999L));
		}
		public override void PostSetupContent()
		{
			// Showcases mod support with Boss Checklist without referencing the mod
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					4.8f,
					new List<int> { ModContent.NPCType<NPCs.Snarbolax.Snarbolax>(), ModContent.NPCType<NPCs.Snarbolax.SnarbyBell>() },
					this, 
					"$Mods.PteranMod.NPCName.Snarbolax",
					(Func<bool>)(() => PteranWorld.downedSnarby),
					ModContent.ItemType<Items.BrokenBeastBell>(),
					new List<int> { ModContent.ItemType<Items.FrumiousFang>()},
					"$Mods.PteranMod.BossSpawnInfo.Snarbolax"
				);
				bossChecklist.Call(
					"AddBoss",
					10.2f,
					new List<int> { ModContent.NPCType<NPCs.Roarmulus.RoarmulusTwin>(), ModContent.NPCType<NPCs.Roarmulus.RoarmulusTwin2>() },
					this,
					"$Mods.PteranMod.NPCName.RoarmulusTwin",
					(Func<bool>)(() => PteranWorld.downedRoar),
					ModContent.ItemType<Items.IronclawMunitionsCrate>(),
					new List<int> { ModContent.ItemType<Items.BarkModule>() },
					"$Mods.PteranMod.BossSpawnInfo.RoarmulusTwin"
				);
			}
		}
	}
}