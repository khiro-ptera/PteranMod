using Microsoft.Xna.Framework;
using PteranMod.Projectiles;
using PteranMod.Items;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace PteranMod.NPCs.Roarmulus
{
	[AutoloadBossHead]
	class RoarmulusTwin2 : ModNPC
	{
		private int ai;
		private int shockBall;
		private int laserCount = 0;
		private bool stunned;
		private int stunnedTimer;
		private int frame;
		public static bool twinTwoDead = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Roarmulus Twin");
			Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 18500;
			npc.damage = 48;
			npc.defense = 999999999;
			npc.knockBackResist = 0f;
			npc.width = 38;
			npc.height = 40;
			npc.scale = 10;
			npc.value = Item.buyPrice(0, 15, 0, 0);
			npc.npcSlots = 4f;
			npc.boss = true;
			npc.HitSound = SoundID.NPCHit34;
			npc.lavaImmune = true;
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.DeathSound = SoundID.NPCDeath14;
			music = MusicID.Boss2;
			//bossBag = mod.ItemType("RoarBag");
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(22500 + 21000 * (numPlayers));
			npc.damage = 76;
		}
		public override void AI()
		{
			twinTwoDead = false;
			/*if(ai == 0)
            {
				NPC.NewNPC((int)npc.position.X + 500, (int)npc.position.Y, mod.NPCType("RoarmulusTwin2"));
			}*/
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
			npc.rotation = 0;
			npc.netAlways = true;
			npc.TargetClosest(true);
			player.AddBuff(BuffID.OgreSpit, 2);
			frame = 1;
			if (ai == 0)
			{
				npc.position.X = player.position.X - 1200;
				npc.position.Y = player.position.Y - 300;
			}
			if(player.position.X < npc.position.X)
			{
				player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " tried to escape the factory."), 800, 0, false);
			}
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				if (npc.target < 0 || npc.target == 255 || !player.active || player.dead || Main.dayTime)
				{
					npc.noTileCollide = true;
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
					return;
				}
			}
			if (stunned)
			{
				npc.defense = 10;
				stunnedTimer++;
				//frame = 6;
				if (stunnedTimer >= 240)
				{
					npc.defense = 999999999;
					stunned = false;
					stunnedTimer = 0;
				}
			}
			else if (npc.life > npc.lifeMax * 0.45f)
			{
				if (ai % 1800 == 0)
				{
					frame = 3;
					Vector2 shootPos = npc.Center;
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-5.0f, 5.0f), Main.rand.NextFloat(-5.0f, 5.0f));
					shootVel.Normalize();
					shootVel *= 2.7f;
					for (int i = 0; i < (Main.expertMode ? 5 : 3); i++)
					{
						int j = i * 10;
						Projectile.NewProjectile(shootPos.X + 250, shootPos.Y + 8 * j - 200,
							shootVel.X, shootVel.Y * 0.6f, mod.ProjectileType("RoarmulusRocket2"),
							(int)(npc.damage * 0.95f), 10f, Main.myPlayer);
					}
				}
				if (ai % 450 == 0) shockBall = 9;
				if(shockBall > 0 && ai % 18 == 0)
				{
					frame = 2;
					Vector2 shootPos = npc.Center;
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-5.0f, 5.0f), Main.rand.NextFloat(-5.0f, 5.0f));
					shootVel.Normalize();
					shootVel *= 3.2f;
					for (int i = 0; i < (Main.expertMode ? 12 : 9); i++)
					{
						int j = i * 10;
						Projectile.NewProjectile(shootPos.X + 250, shootPos.Y + 2 * j - 300 - 25 * (shockBall % 3),
							shootVel.X, shootVel.Y + i - 3.5f, mod.ProjectileType("ShockBall"),
							(int)(npc.damage * 0.3f), 4.6f);
					}
					shockBall--;
				}
			}
			else if (npc.life <= npc.lifeMax * 0.45f)
			{
				if (ai % 1080 == 0)
				{
					frame = 3;
					Vector2 shootPos = npc.Center;
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-5.0f, 5.0f), Main.rand.NextFloat(-5.0f, 5.0f));
					shootVel.Normalize();
					shootVel *= 3.2f;
					for (int i = 0; i < (Main.expertMode ? 6 : 4); i++)
					{
						int j = i * 10;
						Projectile.NewProjectile(shootPos.X + 250, shootPos.Y + 8 * j - 200,
							shootVel.X, shootVel.Y, mod.ProjectileType("RoarmulusRocket2"),
							(int)(npc.damage * 0.95f), 10f, Main.myPlayer);
					}
				}
				if (ai % 360 == 0) shockBall = 12;
				if (shockBall > 0 && ai % 15 == 0)
				{
					frame = 2;
					Vector2 shootPos = npc.Center;
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-5.0f, 5.0f), Main.rand.NextFloat(-5.0f, 5.0f));
					shootVel.Normalize();
					shootVel *= 3.8f;
					for (int i = 0; i < (Main.expertMode ? (15) : (10)); i++)
					{
						int j = i * 10;
						Projectile.NewProjectile(shootPos.X + 250, shootPos.Y + 3 * j - 300 - 25 * (shockBall % 3),
							shootVel.X, shootVel.Y + i - 3.5f, mod.ProjectileType("ShockBall"),
							(int)(npc.damage * 0.35f), 4.6f);
					}
					shockBall--;
				}
				if (ai % 1500 == 244) laserCount = 90;
				if (laserCount > 0)
				{
					frame = 3;
					Vector2 shootPos = npc.Center;
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-5.0f, 5.0f), Main.rand.NextFloat(-5.0f, 5.0f));
					shootVel.Normalize();
					shootVel *= 35f;
					Projectile.NewProjectile(shootPos.X, shootPos.Y,
						shootVel.X, shootVel.Y, mod.ProjectileType("RoarLaser"),
						(int)(npc.damage * 0.3f), 1.8f);
					laserCount--;
				}
				if (npc.life < npc.lifeMax * 0.25f)
				{
					if (ai % 120 == 30)
					{
						Vector2 shootPos = player.position;
						Projectile.NewProjectile(shootPos.X, shootPos.Y - 1000,
							0, 0, mod.ProjectileType("SkyBomb"),
							(int)(npc.damage * 0.7f), 5.8f);
					}

				}
			}
            if (RoarmulusTwin.twinOneDead)
            {
				stunned = true;
            }
			ai++;
			npc.spriteDirection = npc.direction;
			npc.netUpdate = true;
		}
		public override bool CheckDead()
		{
			twinTwoDead = true;
			//npc.dontTakeDamage = true;
			return true;
		}
		public override void FindFrame(int frameHeight)
		{
			if (stunned)
			{
				npc.frame.Y = 9 * frameHeight;
			}
			else if (frame == 2)
			{
				npc.frame.Y = 1 * frameHeight;
			}
			else if (frame == 3)
			{
				npc.frame.Y = 2 * frameHeight;
            }
            else
            {
				npc.frame.Y = 0 * frameHeight;
			}
		}
		public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
		{
			if (projectile.type == ProjectileType<RoarmulusRocket>() || projectile.type == ProjectileType<RoarmulusRocket2>())
			{
				stunned = true;
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{

		}
		public override void NPCLoot()
		{

		}
	}
}
