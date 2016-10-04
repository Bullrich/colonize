using UnityEngine;
using System.Collections;
//By @JavierBullrich

public class ClickHint : MonoBehaviour {

    public GameObject hint;

	void OnEnable()
    {
        Invoke("CloseHint", 3f);
    }

    void CloseHint()
    {
        hint.SetActive(false);
    }
}
