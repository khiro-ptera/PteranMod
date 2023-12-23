using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs;


namespace PteranMod.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class Catalyzed : ModBuff
	{
		public override void SetDefaults()
		{
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<PteranGlobalNPC>().catalyzed = true;
		}
	}
}