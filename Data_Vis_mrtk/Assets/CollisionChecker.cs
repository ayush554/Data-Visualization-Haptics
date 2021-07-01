using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionChecker : MonoBehaviour
{
    public GameObject[] collisionPoints;
    public Material collidedMaterial;
    public Material emptyMaterial;


    MeshRenderer meshRend;
    bool usingCollidedMat;
    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        usingCollidedMat = false;
        meshRend.material = emptyMaterial;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        int pointsTouching = 0;
        for(int i = 0; i < collisionPoints.Length; i++)
        {
            foreach (Collider col in Physics.OverlapBox(collisionPoints[i].transform.position, collisionPoints[i].transform.localScale * .5f, collisionPoints[i].transform.rotation))
            {
                
                if (col.gameObject.tag.Equals("Dataset"))
                {
                    pointsTouching++;
                }
            }
        }
        //Debug.Log(pointsTouching);
        if (pointsTouching >= collisionPoints.Length && !usingCollidedMat)
        {
            meshRend.material = collidedMaterial;
            usingCollidedMat = true;
        }
        if (pointsTouching < collisionPoints.Length && usingCollidedMat)
        {
            meshRend.material = emptyMaterial;
            usingCollidedMat = false;
        }
        if (pointsTouching==0 )
        {
            foreach (Collider col in Physics.OverlapBox(transform.position, transform.localScale * .5f, Quaternion.identity))
            {
                if (col.gameObject.tag.Equals("Dataset"))
                {
                    meshRend.material = collidedMaterial;
                    usingCollidedMat = true;
                }
            }
        }
    }
}