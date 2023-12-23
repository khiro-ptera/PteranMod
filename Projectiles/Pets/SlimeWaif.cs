using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PteranMod.Projectiles.Pets
{
	public class SlimeWaif : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Girl"); 
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			projectile.scale = 0.25f;
			projectile.alpha = 60;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			PteranPlayer modPlayer = player.GetModPlayer<PteranPlayer>();
			if (player.dead)
			{
				modPlayer.slimePet = false;
			}
			if (modPlayer.slimePet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}