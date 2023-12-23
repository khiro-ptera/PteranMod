using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PteranMod.NPCs;


namespace PteranMod.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class Shocked : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shocked");
			Description.SetDefault("Crippled and rapidly losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<PteranPlayer>().shocked = true;
			player.moveSpeed *= 0.7f;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<PteranGlobalNPC>().shocked = true;
		}
	}
}