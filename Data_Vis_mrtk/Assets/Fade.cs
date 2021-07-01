using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Fade : MonoBehaviour
{
    public TextMeshPro fadecolor;
    public Material light;
    public Material dark;
    public MeshRenderer fade_mesh;
    public GameObject Datasets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = Datasets.transform.Find("Lungs Transparent");
        Transform e = Datasets.transform.Find("HumanHead");
        Transform f = Datasets.transform.Find("Clustering Data");
        if (t.gameObject.activeSelf || e.gameObject.activeSelf || f .gameObject.activeSelf)
        {
            GetComponent<MeshRenderer>().material = light;
            fadecolor.color = Color.white;
        }
        else
        {
            GetComponent<MeshRenderer>().material = dark;
            fadecolor.color = Color.grey;
        }
    }
}
