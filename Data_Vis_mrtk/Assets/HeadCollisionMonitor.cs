using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionMonitor : MonoBehaviour
{
    public List<HeadHapticChecker> sensationRegions;
    private bool _touched;
    public bool Touched
    {
        get { return _touched; }
        set
        {
            _touched = value;
            foreach (HeadHapticChecker region in sensationRegions)
            {
                region.UpdateSensation();
            }
        }
    }
    private void Start()
    {
        Touched = false;
    }

    public void SetTouched(bool to)
    {
        Touched = to;
    }
}
