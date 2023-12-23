using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.Items.Weapons
{
	class SpiritSmash : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Does 20 times the enemy defense as damage, capped at 1250.");
		}

		public override void SetDefaults()
		{
			item.damage = 1;
			item.scale = 1.6f;
			item.melee = true;
			item.Size = new Microsoft.Xna.Framework.Vector2(20);
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 50000;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Sparkle>());
			}
		}
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
			item.damage = target.defense * 20;
			if (item.damage > 1250) item.damage = 1250;
			if (item.damage == 0) item.damage = 1;
        }
    }
}
