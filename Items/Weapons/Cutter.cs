using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class Cutter : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 13;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 1.3f;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 3.5f;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 6);
			recipe.AddIngredient(ItemID.Shackle);
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
