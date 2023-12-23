using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using PteranMod.Projectiles;

namespace PteranMod.Items.Weapons
{
	public class SuperBlastBomb : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 180;
			item.magic = true;
			item.mana = 27;
			item.width = 40;
			item.height = 40;
			item.scale = 1.6f;
			item.useTime = 47;
			item.useAnimation = 47;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 7;
			item.value = 5000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SuperBlastBomb");
			item.shootSpeed = 0f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddIngredient(ItemID.Ruby, 10);
			recipe.AddIngredient(ItemType<BlastBomb>());
			recipe.AddIngredient(ItemType<AdvancedOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}