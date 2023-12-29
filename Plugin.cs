using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheChaos.Patches;

namespace TheChaos
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TheChaosModBase : BaseUnityPlugin
    {
        private const string modGUID = "Progression.TheChaos";
        private const string modName = "The Chaos Mod";
        private const string modVersion = "1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TheChaosModBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("TheChaos mod successfully loaded :)");

            harmony.PatchAll(typeof(TheChaosModBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }

    }
}
