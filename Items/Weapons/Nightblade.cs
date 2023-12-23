using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Nightblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A short slicer infused with the essence of the Underworld.");
		}
		public override void SetDefaults()
		{
			item.damage = 18;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 1.2f;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 3;
			item.knockBack = 0.2f;
			item.value = 5000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Brandish>());
			recipe.AddIngredient(ItemID.Obsidian, 22);
			recipe.AddIngredient(ItemID.Amethyst, 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemType<AdvancedOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
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
