using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace PteranMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class FlashscaleMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Ominously reflective." +
				"\nGrants Night Owl buff" +
				"\n7% increased ranged damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 5000;
			item.rare = ItemRarityID.Orange;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<FlashscaleMail>() && legs.type == ItemType<FlashscaleGreaves>();
		}
		public override void UpdateEquip(Player player)
		{
			player.AddBuff(BuffID.NightOwl, 1);
			player.rangedDamage += 0.07f;
			player.rangedCrit += 7;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "15% increased movement speed" +
				"\n5% increased ranged critical strike chance" +
				"\nImmune to On Fire";
			player.moveSpeed += 0.15f;
			player.rangedCrit += 5;
			player.buffImmune[BuffID.OnFire] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SyntheticScale>(), 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}