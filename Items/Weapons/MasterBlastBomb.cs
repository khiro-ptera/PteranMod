using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using PteranMod.Projectiles;

namespace PteranMod.Items.Weapons
{
	public class MasterBlastBomb : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 280;
			item.magic = true;
			item.mana = 35;
			item.width = 40;
			item.height = 40;
			item.scale = 1.8f;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 20000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MasterBlastBomb");
			item.shootSpeed = 0f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.Diamond, 10);
			recipe.AddIngredient(ItemType<SuperBlastBomb>());
			recipe.AddIngredient(ItemType<EliteOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}