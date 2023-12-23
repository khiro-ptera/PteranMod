using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Catalyzer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Left click to fire orbs that rotate around enemies hit." +
				"\nRight click to fire a catalyst to detonate the orbs and deal massive damage based on how many (damage stacks up to 10 orbs)." +
				"\n\"time to get my stupid f**kin gun to work now\"");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.knockBack = 0f;
			item.scale = 1.7f;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.value = 5000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useTime = 50;
				item.useAnimation = 50; 
				item.shootSpeed = 5.5f;
				item.shoot = mod.ProjectileType("Catalyst");
			}
			else
			{
				item.useTime = 30;
				item.useAnimation = 30;
				item.shootSpeed = 5.5f;
				item.shoot = mod.ProjectileType("Catalyst");
			}
			return base.CanUseItem(player);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 0.9f, speedY * 0.9f, mod.ProjectileType("CatalystDetonator"), (int)(damage), knockBack, player.whoAmI);
				return false;
			}
			else return true;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddIngredient(ItemType<FrumiousFang>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}
