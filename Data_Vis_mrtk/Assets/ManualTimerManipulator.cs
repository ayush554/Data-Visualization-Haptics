using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ManualTimerManipulator : MonoBehaviour
{
    public UnityEvent SpacePressed;
    public UnityEvent EscapePressed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpacePressed.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapePressed.Invoke();
        }
    }
}
