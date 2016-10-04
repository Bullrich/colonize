using UnityEngine;
using System.Collections;
using System;
//By @JavierBullrich

public class Spaceship : Building {

    public GameObject rocketParticles;
    private bool canFly = false;

    public override void BuildingComplete()
    {
        //throw new NotImplementedException();
        print("Completed");
    }

    public void Travel()
    {
        if (!building)
        {
            rocketParticles.SetActive(true);
            ColonyManager.instance.coloner.TravelTo(transform.position);
            if (ColonyManager.instance.secondColoner.gameObject.activeInHierarchy)
                ColonyManager.instance.secondColoner.TravelTo(transform.position);
            Invoke("TurnBool", 3f);
            Invoke("GameOver", 16f);
        }
    }
    private float shake = 0.01f;
    void FlyToTheMoon()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        transform.Rotate(0.0f, 0.0f, UnityEngine.Random.Range(-shake * 100, shake * 100));
    }

    void TurnBool()
    {
        canFly = true;
        ColonyManager.instance.coloner.gameObject.SetActive(false);
        if (ColonyManager.instance.secondColoner.gameObject.activeInHierarchy)
            ColonyManager.instance.secondColoner.gameObject.SetActive(false);
    }
	
	void Update () {
        base.Update();
        if (canFly)
            FlyToTheMoon();

    }

    void GameOver()
    {
        ColonyManager.instance.GameOver();
    }
}
