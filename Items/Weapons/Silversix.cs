using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Silversix : ModItem
	{
		private int shot = 0;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Every sixth shot turns into a large, piercing silver bolt.");
		}
		public override void SetDefaults()
		{
			item.damage = 60;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.scale = 1.2f;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 7.2f;
			item.value = 40000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16.5f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (shot == 6)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 0.8f, speedY * 0.8f, mod.ProjectileType("SilverBolt"), (int)(damage * 2.5f), knockBack * 1.8f, player.whoAmI);
				shot = 1;
				return false;
			}
			shot++;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 6);
			recipe.AddIngredient(ItemID.Diamond, 6);
			recipe.AddIngredient(ItemType<Antigua>());
			recipe.AddIngredient(ItemType<EliteOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
