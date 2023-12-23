using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class RadiantPulsar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots very high knockback pulses. Pulsar shots become more powerful the further they travel.");
		}
		public override void SetDefaults()
		{
			item.scale = 2.4f;
			item.damage = 65;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 17.8f;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shootSpeed = 4.5f;
			item.shoot = mod.ProjectileType("RadiantPulsarShot");
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Topaz, 10);
			recipe.AddIngredient(ItemID.Amber, 5);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemType<HeavyPulsar>());
			recipe.AddIngredient(ItemType<EliteOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
