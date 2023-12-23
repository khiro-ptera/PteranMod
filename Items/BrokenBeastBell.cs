using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs.Snarbolax;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items
{
	public class BrokenBeastBell : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons the shadowy beast of the forest after Queen Bee has been defeated.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12; 
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return (NPC.downedQueenBee 
				&& !Main.dayTime 
				&& !player.ZoneJungle
				&& !player.ZoneDungeon
				&& !player.ZoneCorrupt
				&& !player.ZoneCrimson
				&& !player.ZoneHoly
				&& !player.ZoneBeach
				&& !player.ZoneSnow
				&& !player.ZoneUndergroundDesert
				&& !player.ZoneGlowshroom
				&& !player.ZoneMeteor
				&& player.ZoneOverworldHeight);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<Snarbolax>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.DemoniteBar, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.TissueSample, 5);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 5);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.SetResult(this, 1);
			recipe2.AddRecipe();
		}
	}
}