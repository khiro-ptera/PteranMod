using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items
{
	class SyntheticScale : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(silver: 5);
			item.maxStack = 999;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 2);
			recipe.AddIngredient(ItemID.Hellstone, 2);
			recipe.AddIngredient(ItemID.Meteorite, 2);
			recipe.AddIngredient(ItemID.JungleSpores);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
