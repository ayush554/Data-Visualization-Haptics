using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueMaterials : MonoBehaviour
{
    public Material selectedMaterial;
    public Material defaultMaterial;
    private MeshRenderer meshRend;
    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    public void TissueSelected()
    {
        meshRend.material = selectedMaterial;
    }
    public void TissueDeselected()
    {
        meshRend.material = defaultMaterial;
    }
}
