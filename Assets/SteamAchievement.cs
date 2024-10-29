using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamAchievement : MonoBehaviour
{
#if UNITY_STANDALONE || UNITY_EDITOR

    public void IsThisAchievementUnlock(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        Debug.Log($"Achievement {id} status: " + ach.State);
    }

    ////AchievementID : TUTORIAL_COMPLETED

    public void UnlockAchievement(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        ach.Trigger();
        Debug.Log($"Achievement {id} unlocked");
    }

    public void ResetAchievement(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        ach.Clear();
        Debug.Log($"Achievement {id} cleared");
    }
#endif
}
