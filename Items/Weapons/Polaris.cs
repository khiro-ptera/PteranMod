using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Polaris : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("It's said that the explosions caused by this stellar sidearm are so bright you'll always be able to find your way in the darkness. " +
				"\nPolaris shots become more powerful the further they travel.");
		}

		public override void SetDefaults()
		{
			item.scale = 2.5f;
			item.damage = 78;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 17.8f;
			item.value = 90000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shootSpeed = 4.7f;
			item.shoot = mod.ProjectileType("PolarisShot");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire, 15);
			recipe.AddIngredient(ItemID.LightningBug, 3);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 50);
			recipe.AddIngredient(ItemID.LogicGateLamp_Faulty, 25);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemType<GigawattPulsar>());
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
