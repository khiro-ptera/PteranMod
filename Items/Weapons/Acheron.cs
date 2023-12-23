using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Acheron : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Striking with the savage power of the Underworld, " +
				"this dark weapon has been known to drive weak-minded knights to the brink of madness.");
		}
		public override void SetDefaults()
		{
			item.damage = 58;
			item.melee = true;
			item.Size = new Vector2(50);
			item.scale = 1.8f;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 3;
			item.knockBack = 0.6f;
			item.value = 100000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SilentNightblade>());
			recipe.AddIngredient(ItemID.ObsidianSkull);
			recipe.AddIngredient(ItemID.Amethyst, 15);
			recipe.AddIngredient(ItemID.FetidBaghnakhs);
			recipe.AddIngredient(ItemID.FeralClaws);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemType<ShadowSteel>(), 8);
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Spark>());
			}
		}
	}
}
