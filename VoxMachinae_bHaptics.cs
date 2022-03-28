using System;

using MelonLoader;
using HarmonyLib;
using MyBhapticsTactsuit;
using InControl;

namespace VoxMachinae_Bhaptics
{
    public class VoxMachinae_Bhaptics : MelonMod
    {
        public static TactsuitVR tactsuitVr;
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            tactsuitVr = new TactsuitVR();
            tactsuitVr.PlaybackHaptics("HeartBeat");
        }
        
        [HarmonyPatch(typeof(InputDevice), "Vibrate")]
        public class bhaptics_TriggerUsed
        {
            [HarmonyPostfix]
            public static void Postfix(InputDevice __instance)
            {
                if (tactsuitVr.suitDisabled) return;

                tactsuitVr.LOG("VIBRATE ");
            }
        }
    }
}
