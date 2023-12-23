using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items
{
	class FrumiousFang : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Can be traded to the token trader.");
		}
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(silver: 4);
			item.maxStack = 999;
		}
	}
}
