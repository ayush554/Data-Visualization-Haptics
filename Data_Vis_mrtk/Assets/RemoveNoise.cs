using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveNoise : MonoBehaviour
{
    private bool noiseRemoved = false;
    private void Start()
    {
        noiseRemoved = false;
    }
    void CleanNoise()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius * transform.lossyScale.x);
        //Debug.Log(hitColliders.Length);
        //Debug.Log(GetComponent<SphereCollider>().radius * transform.lossyScale.x);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Debug.Log(hitColliders[i].gameObject.name);
            if (hitColliders[i].gameObject.tag.Equals("Noise")){
                hitColliders[i].gameObject.SetActive(false);
            }
        }
        noiseRemoved = true;
    }
    /*
    void IDatasetEvents.ClusterActive()
    {
        Debug.Log("Event called");
        if (!noiseRemoved)
        {
            CleanNoise();
        }
    }
    */
    private void Update()
    {   
        if(!noiseRemoved && transform.lossyScale.x > .001f)
        {
            CleanNoise();
        }
    }
}
