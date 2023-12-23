using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Troika : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 60;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 3f;
			item.useTime = 74;
			item.useAnimation = 74;
			item.useStyle = 1;
			item.knockBack = 9f;
			item.value = 1000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneSlab, 50);
			recipe.AddIngredient(ItemID.GrayBrick, 50);
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddIngredient(ItemType<SimpleOrbOfAlchemy>(), 3);
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
