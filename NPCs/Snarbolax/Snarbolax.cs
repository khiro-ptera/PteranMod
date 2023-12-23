using Microsoft.Xna.Framework;
using PteranMod.Items;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PteranMod.NPCs.Snarbolax
{
    [AutoloadBossHead]
    class Snarbolax : ModNPC
    {
        private int ai;
        private bool stunned;
        private int stunnedTimer;
		private int frame;
		private int noHitPlayerTimer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snarbolax");
            Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 2600;
			npc.damage = 38;
			npc.defense = 3;
			npc.knockBackResist = 0.15f;
			npc.width = 300;
			npc.height = 160;
			npc.dontTakeDamage = true;
			npc.value = Item.buyPrice(0, 7, 0, 0);
			npc.npcSlots = 6f;
			npc.boss = true;
			npc.HitSound = SoundID.NPCHit6;
			npc.lavaImmune = true;
			npc.noTileCollide = false;
			npc.DeathSound = SoundID.NPCDeath5;
			music = MusicID.Boss2;
			bossBag = mod.ItemType("SnarbyBag");
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(4100 + 3700 * (numPlayers));
			npc.damage = 55;
		}
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
			npc.rotation = 0;
			npc.netAlways = true;
			npc.TargetClosest(true); 
			if (!player.active || player.dead || Main.dayTime)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				if (npc.target < 0 || npc.target == 255 || !player.active || player.dead || Main.dayTime)
				{
					npc.noTileCollide = true;
					//npc.noGravity = true;
					//npc.velocity.Y = npc.velocity.Y - 0.1f;
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
					return;
				}
			}
            if (stunned)
            {
				//npc.velocity.Y *= 0.05f;
				npc.velocity.X *= 0.05f;
				stunnedTimer++;
				npc.dontTakeDamage = false;
				frame = 6;
				if (stunnedTimer >= 180)
                {
					stunned = false;
					stunnedTimer = 0;
					npc.dontTakeDamage = true;
				}
            }
			else if(npc.life > npc.lifeMax * 0.25f)
			{
				if(ai % 540 == 0 || ai % 720 == 0)
                {
					frame = 5;
					npc.velocity.Y *= 0.8f;
					npc.velocity.X *= 0.8f;
					Vector2 shootPos = npc.Center;
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-5.0f, 5.0f), Main.rand.NextFloat(-5.0f, 5.0f));
					shootVel.Normalize();
					shootVel *= 12.5f;
					for(int i = 0; i < (Main.expertMode ? 6 : 3); i++)
                    {
						Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + 
							(float)Main.rand.Next(-40, 40), shootPos.Y - (float)Main.rand.Next(-30, 30), 
							shootVel.X, shootVel.Y, mod.ProjectileType("SnarbySpike"), 
							(int)(npc.damage * 0.30f), 5f);
					}
					npc.ai[3] = 20;
				}
			}
			else if (npc.life <= npc.lifeMax * 0.25f)
			{
				if (ai % 360 == 0 || ai % 420 == 0)
				{
					frame = 5;
					npc.velocity.Y *= 0.9f;
					npc.velocity.X *= 0.9f;
					Vector2 shootPos = npc.Center;
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-3.0f, 3.0f), Main.rand.NextFloat(-3.0f, 3.0f));
					shootVel.Normalize();
					shootVel *= 14.5f;
					for (int i = 0; i < (Main.expertMode ? 9 : 6); i++)
					{
						Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) +
							(float)Main.rand.Next(-40, 40), shootPos.Y - (float)Main.rand.Next(-20, 20),
							shootVel.X, shootVel.Y, mod.ProjectileType("SnarbySpike"),
							(int)(npc.damage * 0.55f), 6.5f);
					}
					npc.ai[3] = 20;
				}
			}
			ai++;
			noHitPlayerTimer++;
            if (ai == 1020)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SnarbyBell"));
				npc.ai[0] = 0;
			}
			if(true)
            {
				if (npc.ai[0] > 1020 && SnarbyBell.bellDown)
				{
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SnarbyBell"));
					npc.ai[0] = 0;
				}
				else if (SnarbyBell.bellDown && npc.ai[0] == 0)
				{
					stunned = true;
					npc.ai[0] = 0;
				}
				if (SnarbyBell.bellDown)
                {
					npc.ai[0]++;
				}
				if (ai > 3 && Collision.SolidCollision(npc.Center, npc.width, npc.height) && npc.velocity.X == 0 && npc.velocity.Y == 0)
				{
					//npc.noTileCollide = true;
					npc.velocity.Y -= Main.rand.Next(4, 10);
				}
				npc.ai[2]++;
				npc.ai[3]--;
				if (npc.ai[3] < 1) npc.ai[3] = 0;
				if(noHitPlayerTimer > 600)
                {
					npc.noGravity = true;
					npc.noTileCollide = true;
					npc.velocity.Y -= Main.rand.Next(9, 12);
					npc.ai[2] = 0;
					noHitPlayerTimer = 360;
				}
				if (npc.velocity.X == 0)
                {
					npc.ai[1]++;
					if (npc.ai[1] == 120)
					{
						npc.noTileCollide = true;
						npc.noGravity = true;
						npc.velocity.Y -= Main.rand.Next(8, 10);
						npc.ai[1] = 0;
						npc.ai[2] = 0;
					}
				}
				if (npc.ai[2] == 25)
				{
					npc.noTileCollide = false;
					npc.noGravity = false;
				}
				if (Math.Abs(npc.velocity.X) < 2.5f)
				{
					npc.spriteDirection = -npc.direction;
				}
				if (Math.Abs(npc.velocity.X) < 5)
				{
					npc.velocity += new Vector2(npc.direction * 2.3f, 0);
				}
				if (Collision.SolidCollision(npc.Center, npc.width, npc.height) && npc.velocity.X ==0 && npc.velocity.Y == 0)
				{
					//npc.noTileCollide = true;
					npc.velocity.Y -= 5;
				}
				/*if (npc.collideY && npc.velocity.X == 0)
                {
					if (npc.ai[1] == 3)
					{
						npc.noTileCollide = true;
						npc.velocity.Y -= 18;
						npc.ai[1] = 0;
					}
					else npc.ai[1]++;
					npc.noTileCollide = false;
                }*/
				//MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
				if (!Collision.SolidCollision(npc.Center, npc.width, npc.height) && Math.Abs(npc.velocity.Y) > 0.1)
				{
					frame = 4;
				} else if (npc.ai[3] > 0)
				{
					frame = 5;
 
				} else frame = 1;
				npc.netUpdate = true;
            }
		}
		public override void FindFrame(int frameHeight)
		{
            if (stunned)
            {
				npc.frame.Y = 5 * frameHeight;
			}
			else if (frame == 4)
			{
				npc.frame.Y = 3 * frameHeight;
			}
			else if (frame == 5)
            {
				npc.frame.Y = 4 * frameHeight;
			}
            else
            {
				npc.frameCounter++;
				if (npc.frameCounter < 25)
				{
					npc.frame.Y = 0 * frameHeight;
				}
				else if (npc.frameCounter < 35)
				{
					npc.frame.Y = 1 * frameHeight;
				}
				else if (npc.frameCounter < 45)
				{
					npc.frame.Y = 2 * frameHeight;
				}
				else if (npc.frameCounter < 55)
				{
					npc.frame.Y = 0 * frameHeight;
				}
				else if (npc.frameCounter < 65)
				{
					npc.frame.Y = 1 * frameHeight;
				}
				else if (npc.frameCounter < 75)
				{
					npc.frame.Y = 2 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 240);
			target.AddBuff(BuffID.Venom, 180);
			target.AddBuff(BuffID.Blackout, 50);
			noHitPlayerTimer = 0;
        }
        public override void NPCLoot()
		{
			/*int choice = Main.rand.Next(10);
			int item = 0;
			switch (choice)
			{
				case 0:
					item = ItemType<PuritySpiritTrophy>();
					break;
				case 1:
					item = ItemType<BunnyTrophy>();
					break;
				case 2:
					item = ItemType<TreeTrophy>();
					break;
			}
			if (item > 0)
			{
				Item.NewItem(npc.getRect(), item);
			}*/
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem(npc.getRect(), ItemType<FrumiousFang>(), Main.rand.Next(2, 4));
			}
            if (!PteranWorld.downedSnarby)
            {
				PteranWorld.downedSnarby = true;
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}
		}
	}
}
