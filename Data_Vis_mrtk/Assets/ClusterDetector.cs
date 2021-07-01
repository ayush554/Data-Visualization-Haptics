using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ClusterTracker.Instance.AddCurrentCluster(gameObject.name);
    }
}
