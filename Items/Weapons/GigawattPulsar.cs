using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class GigawattPulsar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots high knockback pulses that have a good chance of shocking enemies." +
				"\nPulsar shots become more powerful the further they travel.");
		}

		public override void SetDefaults()
		{
			item.scale = 2.2f;
			item.damage = 50;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 15.4f;
			item.value = 20000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shootSpeed = 4.6f;
			item.shoot = mod.ProjectileType("GigaPulsarShot");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire, 10);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.BlueWrench);
			recipe.AddIngredient(ItemID.LogicGateLamp_On, 10);
			recipe.AddIngredient(ItemID.LogicGateLamp_Faulty, 3);
			recipe.AddIngredient(ItemType<KilowattPulsar>());
			recipe.AddIngredient(ItemType<EliteOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
