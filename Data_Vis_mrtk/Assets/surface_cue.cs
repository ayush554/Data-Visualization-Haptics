using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surface_cue : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer haptic_area;
    public Material Scar;
    public Material haptic;

    private bool touchingHead;
    void Start()
    {
        touchingHead = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        

        if (collision.gameObject.tag.Equals("datapoints"))
        {

            haptic_area.enabled = true;
            gameObject.GetComponent<MeshRenderer>().material = haptic;
        }

    }
    private void OnTriggerStay(Collider collision)
    {
        if (!haptic_area.enabled && touchingHead && collision.gameObject.tag.Equals("ScarHaptic"))
        {

           haptic_area.enabled = true;
           gameObject.GetComponent<MeshRenderer>().material = Scar;

        } else if (haptic_area.enabled && !touchingHead)
        {
            haptic_area.enabled = false;
        }
        if (collision.gameObject.tag.Equals("HeadHaptic"))
        {
            touchingHead = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("HeadHaptic"))
        {
            touchingHead = false;
        }
        else
        {
            haptic_area.enabled = false;
        }
    }
}
