using HarmonyLib;
using RomenH.Common;

namespace RomenH.GermicideLamp
{
	[HarmonyPatch(typeof(Db))]
	[HarmonyPatch("Initialize")]
	public static class Db_Initialize_Patch
	{
		public static void Prefix()
		{
			StringUtils.AddBuildingStrings(
				GermicideLampConfig.ID,
				ModStrings.STRINGS.BUILDINGS.GERMICIDELAMP.NAME,
				ModStrings.STRINGS.BUILDINGS.GERMICIDELAMP.DESC,
				ModStrings.STRINGS.BUILDINGS.GERMICIDELAMP.EFFECT);
			StringUtils.AddBuildingStrings(
				CeilingGermicideLampConfig.ID,
				ModStrings.STRINGS.BUILDINGS.CEILINGGERMICIDELAMP.NAME,
				ModStrings.STRINGS.BUILDINGS.CEILINGGERMICIDELAMP.DESC,
				ModStrings.STRINGS.BUILDINGS.CEILINGGERMICIDELAMP.EFFECT);
		}

		public static void Postfix()
		{
			BuildingUtils.AddBuildingToPlanScreen(GermicideLampConfig.ID, GameStrings.PlanMenuCategory.Utilities);
			BuildingUtils.AddBuildingToPlanScreen(CeilingGermicideLampConfig.ID, GameStrings.PlanMenuCategory.Utilities);

			BuildingUtils.AddBuildingToTech(GermicideLampConfig.ID, GameStrings.Technology.Medicine.PathogenDiagnostics);
			BuildingUtils.AddBuildingToTech(CeilingGermicideLampConfig.ID, GameStrings.Technology.Medicine.PathogenDiagnostics);
		}
	}
}
