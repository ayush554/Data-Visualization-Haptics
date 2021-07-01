using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNoise : MonoBehaviour
{
    public GameObject noisePrefab;
    public Transform noiseContainer;
    public Transform clusterContainer;

    //Used to establish the range to distribute the noise
    public Transform frontCorner;
    public Transform backCorner;

    public int numberOfPoints;
    [Range(0.0f, 0.05f)]
    public float noiseScale = 0.025f;


    private void Start()
    {
        //Hide the mesh
        GetComponent<MeshRenderer>().enabled = false;

        //Generate the points
        for(int i = 0; i < numberOfPoints; i++)
        {
            //Generate a noise object
            var noiseObj = GameObject.Instantiate(noisePrefab, noiseContainer);
            //Set its position randomly within the cube
            var newX = Random.Range(backCorner.localPosition.x, frontCorner.localPosition.x);
            var newY = Random.Range(backCorner.localPosition.y, frontCorner.localPosition.y);
            var newZ = Random.Range(backCorner.localPosition.z, frontCorner.localPosition.z);
            //Debug.Log(newX + " " + newY + " " + newZ);
            noiseObj.transform.localPosition = new Vector3(newX, newY, newZ);
            //Set its scale
            noiseObj.transform.localScale = new Vector3(noiseScale, noiseScale, noiseScale);

            
            //Check if its colliding with any clusters
            /*foreach(Transform cluster in clusterContainer)
            {
                
                if(Vector3.Magnitude(noiseObj.transform.localPosition - cluster.localPosition) < .35f)
                {
                    Debug.Log(cluster.name + " " + cluster.localPosition + " " + noiseObj.transform.localPosition);
                    noiseObj.SetActive(false);
                }
            }
            */
        }
    }
}

