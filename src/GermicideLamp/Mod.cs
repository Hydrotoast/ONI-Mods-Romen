using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using RomenH.Common;

namespace RomenH.GermicideLamp
{
	public class Mod : UserMod2
	{
		public override void OnLoad(Harmony harmony)
		{
			ModCommon.Init("Germicidal UV Lamps", harmony);

			PUtil.InitLibrary();

			var options = new POptions();
			options.RegisterOptions(this, typeof(ModSettings));

			base.OnLoad(harmony);
		}
	}
}
