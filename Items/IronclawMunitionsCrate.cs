using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs.Roarmulus;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items
{
	public class IronclawMunitionsCrate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons two cute puppies.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 100000;
			item.rare = ItemRarityID.Pink;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !Main.dayTime);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<RoarmulusTwin>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<RoarmulusTwin2>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 3);
			recipe.AddIngredient(ItemID.SoulofMight, 3);
			recipe.AddIngredient(ItemID.SoulofSight, 3);
			recipe.AddIngredient(ItemID.RocketI, 30);
			recipe.AddIngredient(ItemID.RocketII, 30);
			recipe.AddIngredient(ItemID.RocketIII, 30);
			recipe.AddIngredient(ItemID.RocketIV, 30);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}