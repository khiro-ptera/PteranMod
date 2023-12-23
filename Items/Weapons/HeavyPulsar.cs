using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class HeavyPulsar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots high knockback pulses. Pulsar shots become more powerful the further they travel.");
		}
		public override void SetDefaults()
		{
			item.scale = 2.0f;
			item.damage = 33;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 15.2f;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shootSpeed = 4.5f;
			item.shoot = mod.ProjectileType("PulsarShot");
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Topaz, 5);
			recipe.AddIngredient(ItemID.Amber);
			recipe.AddIngredient(ItemType<Pulsar>());
			recipe.AddIngredient(ItemType<AdvancedOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
