using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items.Weapons
{
	public class LongShortsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("LongShortsword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A very long shortsword.");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.melee = true;
			item.width = 70;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 20;
			item.useStyle = 3;
			item.knockBack = 7;
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