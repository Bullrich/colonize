using UnityEngine;
using System.Collections;
//By @JavierBullrich

public class Gold : ResourceParent {

    public ParticleSystem partic;

    public override void Mine(int time, bool waited)
    {
        print("CALLED");
        partic.Simulate(1);
        partic.Play();
        if (!waited)
            StartCoroutine(ParticlePlay(time));
        else {
            ColonyManager.instance.resources.goldObtained += ResourceObtained();
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
