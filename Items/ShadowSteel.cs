using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items
{
	class ShadowSteel : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(silver: 25);
			item.maxStack = 999;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 2); 
			recipe.AddRecipeGroup("IronBar", 2);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
