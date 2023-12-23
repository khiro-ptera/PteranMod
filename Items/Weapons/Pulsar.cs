using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Pulsar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots high knockback pulses." +
				"\nPulsar shots become more powerful the further they travel.");
		}

		public override void SetDefaults()
		{
			item.scale = 1.7f;
			item.damage = 23;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 14.4f;
			item.value = 5000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shootSpeed = 4.5f;
			item.shoot = mod.ProjectileType("PulsarShot");
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
