using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_colliders : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guardian;
    public GameObject HandColliders;
    public GameObject MenuContent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuContent.activeSelf)
        {
            guardian.SetActive(false);
            HandColliders.SetActive(false);

        }
        else
        {
            guardian.SetActive(true);
            HandColliders.SetActive(true);
        }
    }
}
