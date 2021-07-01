using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class OnePlaneCuttingController2 : MonoBehaviour {

    public GameObject plane;
    private GameObject plane2;
    Material mat;
    public Vector3 normal;
    public Vector3 position;
    private Renderer rend;
    // Use this for initialization
    void Start () {
        Transform[] allChildren = plane.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.gameObject.name == "Plane")
            {
                if (child.gameObject.activeSelf)
                {
                    plane2 = child.gameObject;
                    rend = plane2.GetComponent<Renderer>();
                    //normal = plane2.transform.TransformVector(new Vector3(0, 0, -1));
                    //position = plane2.transform.position;
                    UpdateShaderProperties();
                }
               


            }


        }
        
    }
    void Update ()
    {
        Transform[] allChildren = plane.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.gameObject.name == "Plane")
            {
                if (child.gameObject.activeSelf)
                {
                    plane2 = child.gameObject;
                    UpdateShaderProperties();
                }



            }


        }
        
    }

    private void UpdateShaderProperties()
    {
        normal = plane2.transform.up;
        position = plane2.transform.position;
        rend.sharedMaterial.SetVector("_PlaneNormal", normal);
        rend.sharedMaterial.SetVector("_PlanePosition", position);
    }
}
