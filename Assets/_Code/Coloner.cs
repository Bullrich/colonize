using UnityEngine;
using System.Collections;
//By @JavierBullrich

public class Coloner : MonoBehaviour {

    Unit pathFinding;


    #region mining
    bool hasToMine;
    ResourceParent mineObjective;
    int waitTime = 3;
    #endregion

    void Start()
    {
        pathFinding = GetComponent<Unit>();
    }

    public void TravelTo(Vector3 destination)
    {
        pathFinding.NavigateToPoint(transform.position, destination);
    }

    void MineResource(ResourceParent targetResource, bool waited)
    {
        /*int ja = */targetResource.Mine(3, waited);
        hasToMine = false;
        StartCoroutine(WaitAndMine(waitTime));
    }
    IEnumerator WaitAndMine(int time)
    {
        yield return new WaitForSeconds(time + 0.2F);
        if (distanceToTarget(mineObjective.gameObject) < mineObjective.mineDistance)
            mineObjective.Mine(3, true);
    }

    float distanceToTarget(GameObject targetGO)
    {
        float distance = Vector3.Distance(transform.position, targetGO.transform.position);
        return distance;
    }

    public void OrderMining(ResourceParent targetResource)
    {
        mineObjective = targetResource;
        hasToMine = true;
    }


    void Update()
    {
        if (hasToMine)
        {
            if (distanceToTarget(mineObjective.gameObject) < mineObjective.mineDistance)
                MineResource(mineObjective, false);
        }
    }
}
