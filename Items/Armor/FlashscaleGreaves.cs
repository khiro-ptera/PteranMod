using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class FlashscaleGreaves : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Ominously reflective."
				+ "\n10% increased movement speed" +
				"\nGrants immunity to confusion");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 5000;
			item.rare = ItemRarityID.Orange;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Confused] = true;
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SyntheticScale>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
