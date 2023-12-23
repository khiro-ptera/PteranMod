﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items
{
	class EternalOrbOfAlchemy : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(gold: 2);
			item.maxStack = 999;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 2);
			recipe.AddIngredient(ItemID.Hellstone, 2);
			recipe.AddIngredient(ItemID.Meteorite, 2);
			recipe.AddIngredient(ItemID.JungleSpores, 2);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}