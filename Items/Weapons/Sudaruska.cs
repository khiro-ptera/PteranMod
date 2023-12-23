using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Sudaruska : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Brute force gone solar.");
		}
		public override void SetDefaults()
		{
			item.damage = 28282;
			item.melee = true;
			item.Size = new Vector2(80);
			item.scale = 6.9f;
			item.useTime = 888;
			item.useAnimation = 888;
			item.useStyle = 1;
			item.knockBack = 47.5f;
			item.value = 100000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneSlab, 1500);
			recipe.AddIngredient(ItemID.GrayBrick, 1500);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 150);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.Ruby, 10);
			recipe.AddIngredient(ItemType<Khorovod>());
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
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
