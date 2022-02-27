using TUNING;

using UnityEngine;

namespace Curtain
{
	class PlasticCurtainConfig : IBuildingConfig //, IModdedBuilding
	{
		public static string ID = "AC_PlasticCurtain";
		public static string PlanMenu = "Base";
		public static string Tech = "Luxury";
		//public MBInfo Info => new MBInfo(ID, "Base", "Luxury", "Door");

		public override BuildingDef CreateBuildingDef()
		{
			BuildingDef def = BuildingTemplates.CreateBuildingDef(
				 id: ID,
				 width: 1,
				 height: 2,
				 anim: "plasticcurtain_kanim",
				 hitpoints: BUILDINGS.HITPOINTS.TIER1,
				 construction_time: BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER2,
				 construction_mass: BUILDINGS.CONSTRUCTION_MASS_KG.TIER4,
				 construction_materials: new string[] { "AC_FlexibleMaterial" },
				 melting_point: BUILDINGS.MELTING_POINT_KELVIN.TIER0,
				 build_location_rule: BuildLocationRule.Tile,
				 decor: BUILDINGS.DECOR.BONUS.TIER2,
				 noise: NOISE_POLLUTION.NONE
			  );
			def.Overheatable = false;
			def.Floodable = false;
			def.Entombable = false;
			def.IsFoundation = true;
			def.TileLayer = ObjectLayer.FoundationTile;
			def.AudioCategory = "Glass";
			def.PermittedRotations = PermittedRotations.Unrotatable;
			def.SceneLayer = Grid.SceneLayer.Ground;
			def.ForegroundLayer = Grid.SceneLayer.Ground;

			return def;
		}

		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			Prioritizable.AddRef(go);

			Object.DestroyImmediate(go.GetComponent<BuildingEnabledButton>());
			BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);

			go.AddOrGet<ZoneTile>();
			go.AddOrGet<KBoxCollider2D>();
			go.AddOrGet<Workable>().workTime = 3f;
			go.AddOrGet<CopyBuildingSettings>().copyGroupTag = ID;
			go.AddOrGet<BuildingHP>().destroyOnDamaged = true;

			go.AddComponent<Flutterable>();
			go.AddComponent<Curtain>();
			go.AddComponent<Backwall>();
		}

		public override void DoPostConfigureComplete(GameObject go)
		{
			var kbac = go.GetComponent<KBatchedAnimController>();
			kbac.PlayMode = KAnim.PlayMode.Once;
		}
	}
}
