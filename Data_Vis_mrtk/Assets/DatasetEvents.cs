using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDatasetEvents : IEventSystemHandler
{
    // Called when the cluster Dataset has become active and is finished scaling
    void ClusterActive();
   
}
