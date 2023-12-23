using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class SnarbleBarb : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 50;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 1.5f;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 3;
			item.knockBack = 1.6f;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			//for (int i = 0; i < Main.rand.Next(0, 3); i++)
			item.shoot = mod.ProjectileType("SnarbleBarbs");
			item.shootSpeed = 4.5f;
		}
	}
}
