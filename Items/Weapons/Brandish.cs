using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Brandish : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A reliable blade whose lack of ornamentation belies its strength.");
		}
		public override void SetDefaults()
		{
			item.damage = 33;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 1.3f;
			item.useTime = 22;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5.5f;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale, 12);
			recipe.AddIngredient(ItemID.Bone, 12);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddIngredient(ItemType<SimpleOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.TissueSample, 12);
			recipe2.AddIngredient(ItemID.Bone, 12);
			recipe2.AddIngredient(ItemID.Amethyst, 5);
			recipe2.AddIngredient(ItemType<SimpleOrbOfAlchemy>(), 3);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
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
