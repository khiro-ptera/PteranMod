using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Items.Weapons
{
	class CrackedBottle : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.Size = new Microsoft.Xna.Framework.Vector2(30);
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 100;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 120);
		}
	}
}
