using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items.Weapons
{
    class ShortLongsword : ModItem
    {
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("LongShortsword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A very short longsword.");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
			item.Size = new Microsoft.Xna.Framework.Vector2(20);
			item.useTime = 15;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 500;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
