using UnityEngine;
using System.Collections;
//By @JavierBullrich

public abstract class Building : MonoBehaviour {
    public float buildSpeed = 0.2f;
    public bool building;
    public int goldCost, woodCost;

    public void Construct()
    {
        
        gameObject.SetActive(true);

        ColonyManager.instance.RemakeGrid();
        gameObject.transform.localScale = Vector3.zero;
        building = true;
    }

    void StartBuilding()
    {
        float size = gameObject.transform.localScale.z;
        if (size < 1)
        {
            gameObject.transform.localScale += new Vector3(buildSpeed, buildSpeed, buildSpeed) * Time.deltaTime;
        }
        else
        {
            BuildingComplete();
            building = false;
            InterfaceManager.instance.UpdateUI();
        }
    }

    public void Update()
    {
        if (building)
        {
            StartBuilding();
        }
    }

    public abstract void BuildingComplete();
}
