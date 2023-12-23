using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class ArgentPeacemaker : ModItem
	{
		private int shot = 0;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("An ancient handgun forged from sun silver. Its bullets serve as ushers for those that refuse to leave this world." +
				"\nEvery sixth shot turns into a piercing golden eagle with massive damage and knockback inflicting Midas, Daybroken, and Ichor.");
		}
		public override void SetDefaults()
		{
			item.damage = 120;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.scale = 1.4f;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 7.8f;
			item.value = 200000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 21.5f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (shot == 6)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 0.5f, speedY * 0.5f, mod.ProjectileType("ArgentEagle"), (int)(damage * 3f), knockBack * 2.5f, player.whoAmI);
				shot = 1;
				return false;
			}
			shot++;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreBar, 18);
			recipe.AddIngredient(ItemID.Diamond, 12);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.BoneFeather, 2);
			recipe.AddIngredient(ItemType<Silversix>());
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
