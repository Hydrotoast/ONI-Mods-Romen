namespace RomenH.PlasticDoor
{
	public class Backwall : KMonoBehaviour
	{
		KAnimControllerBase masterAnim;
		public override void OnSpawn()
		{
			masterAnim = GetComponent<KAnimControllerBase>();
			Initialize(masterAnim, Grid.SceneLayer.Backwall);
		}

		private void Initialize(KAnimControllerBase master, Grid.SceneLayer layer)
		{
			KBatchedAnimController effect = CreateEffect(master, layer);
			master.SetSymbolVisiblity("back", false);
			new KAnimLink(masterAnim, effect);
		}

		private KBatchedAnimController CreateEffect(KAnimControllerBase master, Grid.SceneLayer layer)
		{
			var effect = FXHelpers.CreateEffect(master.AnimFiles[0].name, transform.position, transform);
			effect.destroyOnAnimComplete = false;
			effect.SetSceneLayer(layer);
			effect.SetFGLayer(layer);
			effect.Play("backwall", KAnim.PlayMode.Paused);

			return effect;
		}
	}
}
