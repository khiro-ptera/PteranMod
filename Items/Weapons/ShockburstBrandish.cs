using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class ShockburstBrandish : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Has a slight chance to shock enemies, dealing constant damage and reducing defense.");
		}
		public override void SetDefaults()
		{
			item.damage = 38;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 1.4f;
			item.useTime = 21;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5.9f;
			item.value = 1000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale, 3);
			recipe.AddIngredient(ItemType<Brandish>());
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddIngredient(ItemID.Sapphire, 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddIngredient(ItemType<AdvancedOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.TissueSample, 3);
			recipe2.AddIngredient(ItemType<Brandish>());
			recipe2.AddIngredient(ItemID.Bone, 5);
			recipe2.AddIngredient(ItemID.Sapphire, 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe2.AddIngredient(ItemType<AdvancedOrbOfAlchemy>(), 3);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (Main.rand.Next(9) < 2) target.AddBuff(mod.BuffType("Shocked"), 60);
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
