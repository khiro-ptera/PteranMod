using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items.Weapons
{
	class ProtoSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("LongShortsword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Standard issue.");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.scale = 1.3f;
			item.melee = true;
			item.Size = new Microsoft.Xna.Framework.Vector2(20);
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 50;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
