using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dataset_Check : MonoBehaviour
{
    public GameObject Datasets;
    public GameObject area;
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
        
        if (t.gameObject.activeSelf|| e.gameObject.activeSelf||f.gameObject.activeSelf)
        {
           // Debug.Log("H");
            area.SetActive(true);
        }
        else
        {
            area.SetActive(false);
        }

    }
}
