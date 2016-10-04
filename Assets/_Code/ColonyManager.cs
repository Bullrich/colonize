using UnityEngine;
using System.Collections;
//By @JavierBullrich

public class ColonyManager : MonoBehaviour {
    //public Coloner[] coloners;
    public Coloner coloner;
    public Coloner secondColoner;
    public GameObject lightMouse;

    public static ColonyManager instance;
    [HideInInspector]
    public ResourceManager resources;

    public Building barrack;
    public Building spaceship;
    [HideInInspector]
    public GameAnalytics analytics;

    bool playing = true;

    Grid gridScript;

    void Update()
    {
        if (playing)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    WorkOnTask(coloner, hit);
                }
                if (Input.GetMouseButtonDown(1) && secondColoner.gameObject.activeInHierarchy)
                {
                    WorkOnTask(secondColoner, hit);
                }
                lightMouse.transform.position = new Vector3(hit.point.x, 0.5F, hit.point.z);
            }
            /*
            if (Input.GetKeyDown("h"))
            {
                barrack.Construct();
                spaceship.Construct();
            }
            //*/
        }
    }

    void WorkOnTask(Coloner col, RaycastHit hitt)
    {
        col.TravelTo(hitt.point);
        if (hitt.transform.gameObject.GetComponent<ResourceParent>() != null)
            col.OrderMining(hitt.transform.gameObject.GetComponent<ResourceParent>());
        else if (hitt.transform.gameObject.GetComponent<Spaceship>() != null)
        {
            hitt.transform.gameObject.GetComponent<Spaceship>().Travel();
        }
    }

    void Start()
    {
        #region ColonerSearcher
        /*GameObject[] colonersGO = GameObject.FindGameObjectsWithTag("Character");
        coloners = new Coloner[colonersGO.Length];
        int i = 0;
        foreach(GameObject col in colonersGO)
        {
            coloners[i] = col.GetComponent<Coloner>();
            i++;
            print(coloners[i].name);
        }
        print("There are " + i + " coloners");
        */
        #endregion

        instance = this;

        gridScript = GameObject.Find("A_").GetComponent<Grid>();
        analytics = GetComponent<GameAnalytics>();
    }

    public void RemakeGrid()
    {
        gridScript.CreateGrid();
    }

    public void GameOver()
    {
        InterfaceManager.instance.congratulations.SetActive(true);
        playing = false;
        analytics.GameCompleted();
    }

    [System.Serializable]
    public class ResourceManager
    {
        public int woodObtained;
        public int goldObtained;
    }
}
