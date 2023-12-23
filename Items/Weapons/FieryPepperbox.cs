using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class FieryPepperbox : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Automatic handgun that turns musket balls into fiery pellets.");
		}
		public override void SetDefaults()
		{
			item.damage = 27;
			item.ranged = true;
			item.scale = 1.5f;
			item.width = 40;
			item.height = 20;
			item.useAnimation = 18;
			item.useTime = 3;
			item.reuseDelay = 21;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3.5f;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 15.2f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ruby, 10);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemType<Pepperbox>());
			recipe.AddIngredient(ItemType<EliteOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
		{
			var posArray = new Vector2[num];
			float spread = (float)(angle * 0.0174532925);
			float baseSpeed = (float)System.Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = System.Math.Atan2(speedX, speedY);
			double randomAngle;
			for (int i = 0; i < num; ++i)
			{
				randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
				posArray[i] = new Vector2(baseSpeed * (float)System.Math.Sin(randomAngle), baseSpeed * (float)System.Math.Cos(randomAngle));
			}
			return (Vector2[])posArray;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return !(player.itemAnimation < item.useAnimation - 2);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileType<Projectiles.FieryPellet>(); // or ProjectileID.FireArrow;
			}
			Vector2[] speeds = randomSpread(speedX, speedY, 8, 6);
			Projectile.NewProjectile(position.X, position.Y, speeds[1].X, speeds[1].Y, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
