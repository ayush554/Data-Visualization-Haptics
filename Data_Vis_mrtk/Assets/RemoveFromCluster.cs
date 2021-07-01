using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromCluster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cluster Shell"))
        {

            Destroy(gameObject);
        }
    }
}
