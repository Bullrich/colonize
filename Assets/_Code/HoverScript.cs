using UnityEngine;
using System.Collections;
//By @JavierBullrich

public class HoverScript : MonoBehaviour {

    Material[] originalMaterials;
    public Material hoverMaterial;
    MeshRenderer meshu;
    Material[] hoverMaterials;

    void Start()
    {
        meshu = GetComponent<MeshRenderer>();
        originalMaterials = meshu.materials;
        hoverMaterials = meshu.materials;
        for(int i = 0; i < hoverMaterials.Length; i++)
        {
            hoverMaterials[i] = hoverMaterial;
        }
    }

	void OnMouseEnter()
    {
        meshu.materials = hoverMaterials;
    }

    void OnMouseExit()
    {
        meshu.materials = originalMaterials;
    }
}
