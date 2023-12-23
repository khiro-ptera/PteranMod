using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class KilowattPulsar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots high knockback pulses that have a slight chance of shocking enemies." +
				"\nPulsar shots become more powerful the further they travel.");
		}

		public override void SetDefaults()
		{
			item.scale = 1.9f;
			item.damage = 27;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 33;
			item.useAnimation = 33;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 14.7f;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shootSpeed = 4.6f;
			item.shoot = mod.ProjectileType("KiloPulsarShot");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire, 5);
			recipe.AddIngredient(ItemID.Amber);
			recipe.AddIngredient(ItemType<Pulsar>());
			recipe.AddIngredient(ItemType<AdvancedOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
