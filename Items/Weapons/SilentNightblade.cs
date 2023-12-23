using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class SilentNightblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Explodes in a fiendish fury.");
		}
		public override void SetDefaults()
		{
			item.damage = 46;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 1.4f;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 3;
			item.knockBack = 0.4f;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Nightblade>());
			recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddIngredient(ItemID.Amethyst, 15);
			recipe.AddIngredient(ItemID.Cog);
			recipe.AddIngredient(ItemID.ObsidianSkull);
			recipe.AddIngredient(ItemType<EliteOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
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
