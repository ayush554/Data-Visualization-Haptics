using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltrahapticsCoreAsset;

public class HeadHapticChecker : MonoBehaviour
{
    public HeadCollisionMonitor mainHead;

    public bool needsHeadCollision;
    public SensationSource senSource;

    private bool _touched;
    public bool Touched
    {
        get { return _touched; }
        set { 
            _touched = value;
            UpdateSensation();
        }
    }
    private void Start()
    {
        Touched = false;
        //senSource = GetComponent<SensationSource>();
    }

    public void UpdateSensation()
    {
        if ((mainHead.Touched || !needsHeadCollision) && Touched && !senSource.enabled)
        {
            senSource.enabled = true;
        } else if (senSource.enabled && ((!mainHead.Touched && needsHeadCollision) || !Touched))
        {
            senSource.enabled = false;
        }
    }

    public void SetTouched(bool to)
    {
        Touched = to;
    }
}
