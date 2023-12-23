using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Boltbrand : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Infused with clockwork technology.");
		}
		public override void SetDefaults()
		{
			item.damage = 57;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 1.8f;
			item.useTime = 21;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6.2f;
			item.value = 1000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire, 15);
			recipe.AddIngredient(ItemID.Cog, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemType<EliteOrbOfAlchemy>(), 3);
			recipe.AddIngredient(ItemType<ShockburstBrandish>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (Main.rand.Next(7) < 2) target.AddBuff(mod.BuffType("Shocked"), 60);
		}
		/*public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Sparkle>());
			}
		}*/
	}
}
