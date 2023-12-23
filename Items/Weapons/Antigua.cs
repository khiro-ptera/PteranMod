using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Antigua : ModItem
	{
		private int shot = 0;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Every sixth shot shoots 2 bullets.");
		}
		public override void SetDefaults()
		{
			item.damage = 48;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.scale = 1.0f;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6.5f;
			item.value = 5500;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 14f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (shot == 6)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				shot = 0;
			}
			shot++;
			return true;
		}
	}
}
