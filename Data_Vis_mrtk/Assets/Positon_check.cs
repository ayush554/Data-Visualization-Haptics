using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positon_check : MonoBehaviour
{
   
    public GameObject menu;
    public GameObject guardian;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        if(gameObject.activeSelf)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
        if (transform.parent == null)
        {
            

        }
        else
        {
            if (transform.parent.name == "Palm Proxy Transform")
            {
                /*transform.position = new Vector3(0f, 0f, 1.3f);
                transform.localEulerAngles = new Vector3(90, 0, 0);*/
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<BoxCollider>().enabled = true;
                guardian.SetActive(false);

                
                /*if(transform.position.x!=0)
                transform.position = new Vector3(0, 0, 1);*/
                
            }
           

            
            
        }
    }
}
