using System.Reflection;
using HarmonyLib;
using OWML.Common;
using OWML.ModHelper;

namespace CTFTemplate
{
    public interface ICaptureTheAPI
    {
        public string Echo(string input);
    }
    public class CTFTemplate : ModBehaviour
    {
        public static CTFTemplate Instance;
        public INewHorizons NewHorizons;

        public void Awake()
        {
            Instance = this;
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        public void Start()
        {
            // Starting here, you'll have access to OWML's mod helper.
            ModHelper.Console.WriteLine($"Loaded the CTF Template/Example.", MessageType.Success);

            // Get the New Horizons API and load configs
            NewHorizons = ModHelper.Interaction.TryGetModApi<INewHorizons>("xen.NewHorizons");
            NewHorizons.LoadConfigs(this);

            var CaptureTheAPI = ModHelper.Interaction.TryGetModApi<ICaptureTheAPI>("Onbvb.CaptureTheFlag");
            ModHelper.Console.WriteLine(CaptureTheAPI.Echo("CTF Template called for CTF Mod and Succeeded!"), MessageType.Success);

            new Harmony("Onbvb.CTFTemplate").PatchAll(Assembly.GetExecutingAssembly());

            // Example of accessing game code.
            OnCompleteSceneLoad(OWScene.TitleScreen, OWScene.TitleScreen); // We start on title screen
            LoadManager.OnCompleteSceneLoad += OnCompleteSceneLoad;
        }

        public void OnCompleteSceneLoad(OWScene previousScene, OWScene newScene)
        {
            if (newScene != OWScene.SolarSystem) return;
            ModHelper.Console.WriteLine("Loaded into solar system!", MessageType.Success);
        }
    }

}
