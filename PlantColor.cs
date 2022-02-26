using MelonLoader;
using UnityEngine;

namespace PlantColor
{
    public class PlantColorMain : MelonMod
    {

		//Plants
		public static Color defaultPlantColor = new Color (0.362f, 0.5569f, 0.4292f, 1f);
		public static Color plantColor = new Color(0.362f, 0.5569f, 0.4292f, 1f);
		public static Material plantMat;
		public static bool isInitialized = false;




		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			if (sceneName == "Placemaker")
			{
				MelonLogger.Msg("Main scene loaded");

				// Initializing
				//Initialize();
				PlantsUI.Initialize(this);

			}
		}

		public static void Initialize()
        {

			GameObject gameObject = GameObject.Find("Plants");
			if (gameObject != null)
			{
				plantMat = gameObject.GetComponent<Placemaker.BigMeshGroup>().material;
				plantColor = plantMat.color;
				isInitialized = true;
			}
        }

		public static void Reset()
		{
			plantColor.r = defaultPlantColor.r;
			plantColor.g = defaultPlantColor.g;
			plantColor.b = defaultPlantColor.b;
			plantMat.color = plantColor;
		}

		public override void OnApplicationStart()
		{
			
		}

		public override void OnUpdate()
		{
			if (isInitialized == false)
            {
				Initialize();
            }
		}

	}
}

