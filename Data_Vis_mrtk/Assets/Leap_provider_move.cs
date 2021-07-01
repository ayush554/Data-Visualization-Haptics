using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap_provider_move : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;
    private Transform leap;
    public GameObject parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leap = camera.transform.Find("LeapProvider");
        if(leap)
        {
            leap.SetParent(parent.transform);
            leap.localPosition = Vector3.zero;
            leap.localEulerAngles = Vector3.zero;
        }
    }
}
