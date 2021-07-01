using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translation : MonoBehaviour
{
    private GameObject activeDataset;
    public GameObject Guardian;
    public GameObject tool;
    /*  Index to datasets
 *  0 - Lungs
 *  1 - Head
 *  2 - Cluster
 */
    private Vector3[] targetPositionsFar =
    {
        new Vector3(-.12f, .52f, 1.64f),
        new Vector3(-.02347f, .27f, 1.41f),
        new Vector3(-.48f, -.21f, 1.06f)
    };
    private Vector3[] targetScalesFar =
    {
        new Vector3(.7f, .7f, .7f),
        new Vector3(2f, 2f, 2f),
        new Vector3(.75f, .75f, .75f)
    };
    private Vector3[] targetScalesNear =
    {
        new Vector3(.2f, .2f, .2f),
        new Vector3(1.37f, 1.37f, 1.37f),
        new Vector3(.35f, .35f, .35f)
    };
    private Vector3[] targetPositionsNear =
    {
        new Vector3(.035f, .263f, .19f),
        new Vector3(.035f, .135f, .24f),
        new Vector3(-.218f, -.101f, 0.04405912f)
    };
    private Vector3[] targetPositionsTool =
    {
        new Vector3(-.27f, .095f, 1.056f),
        new Vector3(.08f, .095f, 1.733f),
        new Vector3(-.027f, .095f, 1.27f)
    };
    private Vector3[] targetScalesTool =
    {
        new Vector3(.219f, .311f, .037f),
        new Vector3(.39f, .38f, .032f),
        new Vector3(.278f, .438f, .042f)
    };
    private int activeIndex = 0;

    IEnumerator FarRoutine()
    {
        var targetPos = targetPositionsFar[activeIndex];
        tool.SetActive(false);
       
        while (Vector3.Magnitude(activeDataset.transform.position - targetPos) > .1f)
        {
            activeDataset.transform.position = Vector3.Lerp(activeDataset.transform.position, targetPos, .1f);
            yield return new WaitForSeconds(.02f);
        }
        tool.SetActive(true);


    }
    IEnumerator NearRoutine()
    {
        var targetPos = targetPositionsNear[activeIndex];
        while (Vector3.Magnitude(activeDataset.transform.position - targetPos) > .1f)
        {
            activeDataset.transform.position = Vector3.Lerp(activeDataset.transform.position, targetPos, .1f);
            yield return new WaitForSeconds(.02f);
        }
        Guardian.SetActive(true);
    }
    IEnumerator GoToScaleFar()
    {
        float targetScale = targetScalesFar[activeIndex].x;
        while(Mathf.Abs(activeDataset.transform.localScale.x - targetScale) > .01f)
        {
            activeDataset.transform.localScale = Vector3.Lerp(activeDataset.transform.localScale, new Vector3(targetScale, targetScale, targetScale), .2f);
            yield return new WaitForSeconds(.02f);
        }
    }
    IEnumerator GoToScaleNear()
    {
        float targetScale = targetScalesNear[activeIndex].x;
        while (Mathf.Abs(activeDataset.transform.localScale.x - targetScale) > .01f)
        {
            activeDataset.transform.localScale = Vector3.Lerp(activeDataset.transform.localScale, new Vector3(targetScale, targetScale, targetScale), .2f);
            yield return new WaitForSeconds(.02f);
        }
    }
    public GameObject scandataset()
    {
        Transform t = transform.Find("Lungs Transparent");
        Transform e = transform.Find("HumanHead");
        Transform f = transform.Find("Clustering Data");
        if (t.gameObject.activeSelf)
        {
            activeDataset = t.gameObject;
            activeIndex = 0;
        }
        if (e.gameObject.activeSelf)
        {
            activeDataset = e.gameObject;
            activeIndex = 1;
        }
        if (f.gameObject.activeSelf)
        {
            activeDataset = f.gameObject;
            activeIndex = 2;
        }
        return activeDataset;
    }

    public void RunCorrectRoutine()
    {
        activeDataset = scandataset();
        if (!tool.activeSelf)
        {
            StopAllCoroutines();
            //activeDataset.transform.position = new Vector3(-0.027f, 0.095f, 1.27f);
            StartCoroutine(GoToScaleNear());
            StartCoroutine(NearRoutine());

        } else
        {
            StopAllCoroutines();
            StartCoroutine(GoToScaleFar());
            StartCoroutine(FarRoutine());
            tool.transform.position = targetPositionsTool[activeIndex];
            tool.transform.localScale = targetScalesTool[activeIndex];
        }
    }
}

