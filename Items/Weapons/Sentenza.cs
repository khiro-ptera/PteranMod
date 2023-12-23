using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Sentenza : ModItem
	{
		private int shot = 0;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("An ancient handgun forged from shadow steel." +
				"\nEvery sixth shot turns into a piercing shadow eagle with massive damage and knockback inflicting Shadowflame and Betsy's Curse.");
		}
		public override void SetDefaults()
		{
			item.damage = 160;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.scale = 1.4f;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8.2f;
			item.value = 200000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 19.5f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (shot == 6)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 0.35f, speedY * 0.35f, mod.ProjectileType("ShadowEagle"), (int)(damage * 3.5f), knockBack * 2.5f, player.whoAmI);
				shot = 1;
				return false;
			}
			shot++;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amethyst, 18);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemID.GiantHarpyFeather, 2);
			recipe.AddIngredient(ItemType<ShadowSteel>(), 12);
			recipe.AddIngredient(ItemType<Blackhawk>());
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
