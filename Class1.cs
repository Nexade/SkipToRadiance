using Modding;
using System;
using UnityEngine;
using Unity;
using JetBrains.Annotations;
using SFCore;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace SkipToRadiance
{
    public class SkipToRadiance : Mod, ITogglableMod
    {
        public override string GetVersion() => "1.0";

        bool RadianceEncountered = false;
        public override void Initialize()
        {
            ModHooks.OnEnableEnemyHook += ModHooks_OnEnableEnemyHook;
        }

        private bool ModHooks_OnEnableEnemyHook(GameObject obj, bool isAlreadyDead)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Dream_Final_Boss")
            {
                RadianceEncountered = true;
            }
            if (obj.name.Contains("Hollow Knight Boss") && RadianceEncountered)
            {
                obj.LocateMyFSM("Phase Control").SetState("Set Phase 4");
            }
            return isAlreadyDead;
        }
        public void Unload()
        {
            ModHooks.OnEnableEnemyHook -= ModHooks_OnEnableEnemyHook;
        }
    }
}
