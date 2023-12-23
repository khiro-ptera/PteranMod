using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using PteranMod.Projectiles;

namespace PteranMod.Items.Weapons
{
	public class BlastBomb : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 120;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.scale = 1.4f;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlastBomb");
			item.shootSpeed = 0f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 25);
			recipe.AddIngredient(ItemID.Diamond, 3);
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddIngredient(ItemType<SimpleOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}