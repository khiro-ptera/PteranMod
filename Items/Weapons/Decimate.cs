using PteranMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items.Weapons
{
	public class Decimate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decimate");
			Tooltip.SetDefault("This Noxian guillotine inflicts up to 5 stacks of hemorrhage, " +
				"dealing more continuous damage per stack. \nHeals the user when Decimate hits an enemy.");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(gold: 8);
			item.rare = ItemRarityID.Quest;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 75;
			item.useTime = 75;
			item.knockBack = 5f;
			item.damage = 151;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<DecimateAxe>();
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 9;
			item.channel = true;
		}
	}
}