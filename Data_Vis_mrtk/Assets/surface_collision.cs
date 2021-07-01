using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surface_collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("true");
        if (collision.gameObject.tag.Equals("scanner"))
        {

            Debug.Log("true");
        }

    }
    void OnCollisionExit(Collision collision)
    {

        Debug.Log("false");
    }
}

