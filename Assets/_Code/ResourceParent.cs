using UnityEngine;
using System.Collections;
//By @JavierBullrich

public abstract class ResourceParent : MonoBehaviour {

    public int MaxSizeResource;
    [Range(0.01F, 0.6F)]
    public float growSpeed = 0.1F;
    int resource;
    bool canBeMined;
    public float mineDistance = 3;

    public virtual void GetResource()
    {

    }

    public virtual void Grow()
    {
        float size = gameObject.transform.localScale.z;
        if (size < 1)
            gameObject.transform.localScale += new Vector3(growSpeed, growSpeed, growSpeed) * Time.deltaTime;
        if (size > 0.5F)
            canBeMined = true;
    }

    public virtual void Update()
    {
        Grow();
        
        if (Input.GetKeyDown("l"))
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        
    }

    public int ResourceObtained()
    {
        if (canBeMined)
        {
            resource = (int)(MaxSizeResource * gameObject.transform.localScale.z);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            canBeMined = false;
        }
        else
            resource = 0;
        print(ColonyManager.instance.resources.woodObtained + " W, G " + ColonyManager.instance.resources.goldObtained);
        return resource;
    }

    public virtual void Mine(int time, bool waited)
    {

    }
}
