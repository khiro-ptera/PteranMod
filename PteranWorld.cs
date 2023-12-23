using PteranMod.Items;
using PteranMod.NPCs;
//using PteranMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace PteranMod
{
	public class PteranWorld : ModWorld
	{
		public static bool downedSnarby;
		public static bool downedRoar;
		public override void Initialize()
		{
			downedSnarby = false;
			downedRoar = false;
		}

		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedSnarby)
			{
				downed.Add("snarbolax");
			}
			if (downedRoar)
			{
				downed.Add("roarmulus");
			}
			return new TagCompound
			{
				["downed"] = downed,
			};
		}
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedSnarby = downed.Contains("snarbolax");
			downedRoar = downed.Contains("roarmulus");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedSnarby = flags[0];
				downedRoar = flags[1];
			}
			else
			{
				mod.Logger.WarnFormat("PteranMod: Unknown loadVersion: {0}", loadVersion);
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedSnarby;
			flags[1] = downedRoar;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedSnarby = flags[0];
			downedRoar = flags[1];
		}
	}
}