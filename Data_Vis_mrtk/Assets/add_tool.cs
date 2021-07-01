using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_tool : MonoBehaviour
{
    public GameObject tool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount==0)
        {
            GameObject dataPoint = Instantiate(tool, Vector3.zero, Quaternion.identity);
            dataPoint.SetActive(false);
            dataPoint.name = "Tool";
            dataPoint.transform.parent = gameObject.transform;
        }
    }
}
