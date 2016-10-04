using UnityEngine;
using System.Collections;
using System;
//By @JavierBullrich

public class Barrack : Building {
    public override void BuildingComplete()
    {
        print("HELLO");
        ColonyManager.instance.secondColoner.gameObject.SetActive(true);
        ColonyManager.instance.analytics.BarrackBuilt();
    }
}
