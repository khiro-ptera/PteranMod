using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Supernova : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The destruction left in the wake of this peerless pistol is anything but nebulous." +
				"\nSupernova shots become more powerful the further they travel.");
		}

		public override void SetDefaults()
		{
			item.scale = 2.8f;
			item.damage = 111;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 20.5f;
			item.value = 90000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shootSpeed = 4.7f;
			item.shoot = mod.ProjectileType("SupernovaShot");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Topaz, 15);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 25);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell, 5);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemType<RadiantPulsar>());
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
