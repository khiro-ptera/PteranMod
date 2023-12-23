using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class DruvasksJawbone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drüvask's Jawbone");
			Tooltip.SetDefault("Gnar gada.");
		}

		public override void SetDefaults()
		{
			item.damage = 185;
			item.noMelee = true;
			item.ranged = true;
			item.Size = new Vector2(40);
			item.scale = 1.5f;
			item.useTime = 25;
			item.useAnimation = 25;
			item.noUseGraphic = true;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 5000;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true; item.shoot = mod.ProjectileType("DruvasksJawbone");
			item.shootSpeed = 5.5f;
		}
		public override bool CanUseItem(Player player)       
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
				{
					return false;
				}
			}
			return true;
		}
		/*public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(mod.BuffType("Shocked"), 120);
		}*/
	}
}
