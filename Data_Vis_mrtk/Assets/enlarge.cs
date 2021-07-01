using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enlarge : MonoBehaviour
{
    //For experiment where objects cant be moved
    public bool runInStaticMode;
    private Transform t;
    private Transform e;
    private Transform f;

    private Transform activeDataset;
    private Coroutine growing;

    private GameObject clusters;

    /*  Index to datasets
     *  0 - Lungs
     *  1 - Head
     *  2 - Cluster
     */
    private Vector3[] startPositions =
    {
        new Vector3(.035f, .263f, .19f),
        new Vector3(.035f, .135f, .24f),
        new Vector3(-.218f, -.101f, 0.04405912f)
        
    };
    private Vector3[] startPositionsStaticMode =
    {
        new Vector3(-.12f, .52f, 1.64f),
        new Vector3(-0.0199999996f,0.208000004f,0.5f),
        new Vector3(-.48f, -.21f, 1.06f)
    };
    private Vector3[] startPositionToolStatic =
    {
        new Vector3(-.12f, .52f, 1.64f),
        new Vector3(-0.0234699994f,0.326999992f,1.84000003f),
        new Vector3(-.48f, -.21f, 1.06f)
    };
    private Vector3[] startScales =
    {
        new Vector3(.2f, .2f, .2f),
        new Vector3(1.37f, 1.37f, 1.37f),
        new Vector3(.35f, .35f, .35f)
    };
    private Vector3[] startScalesStaticMode =
    {
        new Vector3(.2f, .2f, .2f),
        new Vector3(2.4f, 2.4f, 2.4f),
        new Vector3(.35f, .35f, .35f)
    };
    private Vector3[] startScalesToolStatic =
{
        new Vector3(.2f, .2f, .2f),
        new Vector3(2.4f, 2.4f, 2.4f),
        new Vector3(.35f, .35f, .35f)
    };
    // Start is called before the first frame update
    void Start()
    {
        activeDataset = null;
         t = transform.Find("Lungs Transparent");
         e = transform.Find("HumanHead");
         f = transform.Find("Clustering Data");
        t.localScale = Vector3.zero;
        e.localScale = Vector3.zero;
        f.localScale = Vector3.zero;

        clusters = GameObject.Find("Clusters");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeActiveDataset(Transform newDataset)
    {   
        if(activeDataset == newDataset)
        {
            return;
        }
        float size = 0f;
        if (newDataset.gameObject.name == "Lungs Transparent")
        {
            size = startScales[0].x;
            newDataset.position = runInStaticMode ? startPositionsStaticMode[0] : startPositions[0];
        }
        if (newDataset.gameObject.name == "HumanHead")
        {

            if (ToolManager.Instance.toolModeEnabled && runInStaticMode)
            {
                newDataset.position = startPositionToolStatic[1];
                size = startScalesToolStatic[1].x;
            } else
            {
                newDataset.position = runInStaticMode ? startPositionsStaticMode[1] : startPositions[1];
                size = runInStaticMode ? startScalesStaticMode[1].x : startScales[1].x;
            }
            

        }
        if (newDataset.gameObject.name == "Clustering Data")
        {
            size = startScales[2].x;
            newDataset.position = runInStaticMode ? startPositionsStaticMode[2] : startPositions[2];
        }
        newDataset.localEulerAngles = Vector3.zero;
        if (activeDataset != null)
        {
            if (growing != null)
            {
                StopCoroutine(growing);
            }
            StartCoroutine(Shrink(activeDataset));
        }
        growing = StartCoroutine(Grow(newDataset,size));
        activeDataset = newDataset;
    }
    IEnumerator Shrink(Transform e)
    {
        
        while (e.localScale.x > .01f)
        {
            e.localScale = Vector3.Lerp(e.localScale, new Vector3(0, 0, 0), .2f);
            yield return new WaitForSeconds(.02f);
        }
        e.gameObject.SetActive(false);
        yield return null;
    }
   

    IEnumerator Grow(Transform f, float size)
    {
        f.gameObject.SetActive(true);
        while (f.localScale.x < size - .01f)
        {
            f.localScale = Vector3.Lerp(f.localScale, new Vector3(size, size, size), .2f); 
            
            yield return new WaitForSeconds(.02f);
        }
        Debug.Log("1");
        //Layers.SetActive(false);
        /*
        if(activeDataset.gameObject.name.Equals("Clustering Data"))
        {
            Debug.Log("2");
            //Tell the clusters that they can remove the noise within them
            var noiseRemovers = GetComponentsInChildren<RemoveNoise>(clusters);
            foreach (var noiseRemover in noiseRemovers)
            {
                //ExecuteEvents.Execute<IDatasetEvents>(noiseRemover.gameObject, null, (x, y) => x.ClusterActive());
            }
        }
        */
    }
   
}
