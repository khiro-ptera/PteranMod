using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items
{
	class BarkModule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Can be traded to the token trader.");
		}
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.sellPrice(silver: 40);
			item.maxStack = 999;
		}
	}
}
