using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ClusterTracker : MonoBehaviour
{
    private static ClusterTracker _instance;
    public static ClusterTracker Instance => _instance ? _instance : FindObjectOfType<ClusterTracker>();
    private List<string> touchedClusters;
    private TextMeshPro txtComponent;
    private string lastStringVal;
    void Start()
    {
        txtComponent = GetComponent<TextMeshPro>();
        touchedClusters = new List<string>();
        txtComponent.enabled = false;
    }

    public void AddCurrentCluster(string clusterName)
    {
        //Debug.Log("Adding text");
        lastStringVal = clusterName;
        txtComponent.text = "Current Cluster: " + lastStringVal;
        touchedClusters.Add(clusterName);
        if(txtComponent.enabled == false)
        {
            txtComponent.enabled = true;
        }
    }

    public void RemoveCurrentCluster(string clusterName)
    {
        //Debug.Log("Removing text");
        touchedClusters.Remove(clusterName);
        
        if (touchedClusters.Count > 0)
        {
            lastStringVal = touchedClusters[touchedClusters.Count - 1];
            txtComponent.text = "Current Cluster: " + lastStringVal;
        } else
        {
            txtComponent.enabled = false;
        }
    }
    public void AddCurrentTissue(string tissueName)
    {
        //Debug.Log("Adding text");
        lastStringVal = tissueName;
        txtComponent.text = "Current Tissue: " + lastStringVal;
        touchedClusters.Add(tissueName);
        if (txtComponent.enabled == false)
        {
            txtComponent.enabled = true;
        }
    }
    public void RemoveCurrentTissue(string tissueName)
    {
        //Debug.Log("Removing text");
        touchedClusters.Remove(tissueName);
        if (touchedClusters.Count > 0)
        {
            lastStringVal = touchedClusters[touchedClusters.Count - 1];
            txtComponent.text = "Current Tissue: " + lastStringVal;
        }
        else
        {
            txtComponent.enabled = false;
        }
    }
    public string GetMostRecentValue()
    {
        return lastStringVal;
    }
}
