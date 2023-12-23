using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Accessories
{
	public class Unidentified : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("???");
			Tooltip.SetDefault("???");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Quest;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<PteranPlayer>().what = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand)
		{
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Damselfish, 23);
			recipe.AddIngredient(ItemID.EndurancePotion, 3);
			recipe.AddIngredient(ItemID.GemLockEmerald);
			recipe.AddIngredient(ItemID.GlassTable, 12);
			recipe.AddIngredient(ItemID.FancyGreyWallpaper, 568);
			recipe.AddIngredient(ItemID.AlphabetStatueX, 6);
			recipe.AddIngredient(ItemID.MetalSink, 13);
			recipe.AddIngredient(ItemID.OrangePaint, 4343);
			recipe.AddIngredient(ItemID.GlowingSnailCage, 2);
			recipe.AddIngredient(ItemID.Fake_MeteoriteChest, 5);
			recipe.AddIngredient(ItemID.HallowedWaterFountain, 9);
			recipe.AddTile(TileID.FleshBlock);
			recipe.AddTile(TileID.HallowSandstone);
			recipe.AddTile(TileID.LogicSensor);
			recipe.AddTile(TileID.RedAdmiralButterflyJar);
			recipe.AddTile(TileID.Pigronata);
			recipe.AddTile(TileID.BlueDynastyShingles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}