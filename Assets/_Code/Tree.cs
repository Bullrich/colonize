using UnityEngine;
using System.Collections;
//By @JavierBullrich

public class Tree : ResourceParent {

    public ParticleSystem partic;

    public override void Mine(int time, bool waited)
    {
        partic.Simulate(1);
        partic.Play();
        if (!waited)
            StartCoroutine(ParticlePlay(time));
        else {
            ColonyManager.instance.resources.woodObtained += ResourceObtained();
            InterfaceManager.instance.UpdateUI();
            partic.Stop();
        }
    }

    IEnumerator ParticlePlay(int time)
    {
        yield return new WaitForSeconds(time);
        partic.Stop();
    }
}
