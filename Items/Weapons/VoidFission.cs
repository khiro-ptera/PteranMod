using PteranMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	public class VoidFission : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Knowledge through disintegration." +
				"\nProjectiles split in a T shape when destroyed. Inflicts Shadowflame, Ichor, and Shocked.");
			Item.staff[item.type] = true; 
		}

		public override void SetDefaults()
		{
			item.damage = 202;
			item.magic = true;
			item.mana = 16;
			item.width = 40;
			item.height = 40;
			item.scale = 1.8f;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 100000;
			item.rare = ItemRarityID.Quest;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<FissionBolt>();
			item.shootSpeed = 2.8f;
		}
	}
}