using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using PteranMod.Projectiles;

namespace PteranMod.Items.Weapons
{
	public class Nitronome : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Boom.");
		}
		public override void SetDefaults()
		{
			item.damage = 550;
			item.magic = true;
			item.mana = 40;
			item.width = 40;
			item.height = 40;
			item.scale = 2.3f;
			item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 90000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Nitronome");
			item.shootSpeed = 0f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ExplosivePowder, 50);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddIngredient(ItemType<MasterBlastBomb>());
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}