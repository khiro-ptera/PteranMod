using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class ObsidianEdge : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Simply holding it makes you somehow feel guilty of an unknown crime.");
		}
		public override void SetDefaults()
		{
			item.damage = 152;
			item.melee = true;
			item.Size = new Vector2(40);
			item.scale = 2.3f;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 9.5f;
			item.value = 100000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ApocreanTentacles");
			item.shootSpeed = 3.2f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SilentNightblade>());
			recipe.AddIngredient(ItemID.Obsidian, 300);
			recipe.AddIngredient(ItemID.SpookyWood, 300);
			recipe.AddIngredient(ItemID.Amethyst, 15);
			recipe.AddIngredient(ItemID.ObsidianSwordfish);
			recipe.AddIngredient(ItemID.ObsidianRose);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemType<EternalOrbOfAlchemy>(), 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 180);
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Shade>());
			}
		}
	}
}
