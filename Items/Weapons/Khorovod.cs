using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Khorovod : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A real backbreaker.");
		}
		public override void SetDefaults()
		{
			item.damage = 580;
			item.melee = true;
			item.Size = new Vector2(50);
			item.scale = 4.0f;
			item.useTime = 100;
			item.useAnimation = 100;
			item.useStyle = 1;
			item.knockBack = 17.5f;
			item.value = 50000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneSlab, 500);
			recipe.AddIngredient(ItemID.GrayBrick, 500);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.Ruby, 10);
			recipe.AddIngredient(ItemType<Kamarin>());
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
