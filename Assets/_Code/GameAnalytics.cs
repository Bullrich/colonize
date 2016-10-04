using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;
//By @JavierBullrich

public class GameAnalytics : MonoBehaviour {

    public void GameCompleted()
    {
        Analytics.CustomEvent("GameCompleted", new Dictionary<string, object>
          {
            { "Time", Time.timeSinceLevelLoad },
            { "Wood", ColonyManager.instance.resources.woodObtained },
            { "Gold", ColonyManager.instance.resources.goldObtained }
          });
    }

    public void BarrackBuilt()
    {
        Analytics.CustomEvent("BarrackBuilt", new Dictionary<string, object>
          {
            { "Time", Time.timeSinceLevelLoad },
            { "Wood", ColonyManager.instance.resources.woodObtained },
            { "Gold", ColonyManager.instance.resources.goldObtained }
          });
    }
}
