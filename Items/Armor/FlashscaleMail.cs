using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class FlashscaleMail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Flashscale Mail");
			Tooltip.SetDefault("Ominously reflective." +
				"\n+25 max health" +
				"\n5% damage reduction");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 5000;
			item.rare = ItemRarityID.Orange;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 25;
			player.endurance += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SyntheticScale>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}