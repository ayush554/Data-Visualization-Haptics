
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI.BoundsControlTypes;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Experimental.Physics;

namespace UnityEngine.Rendering.PostProcessing
{
    public class Collision_Outline : MonoBehaviour
    {
        public Outline outline;
        private readonly HashSet<Collider> entered_ = new HashSet<Collider>();
        private readonly System.Predicate<Collider> IsNull = c => c == null || !c.enabled || !c.gameObject.activeInHierarchy;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (entered_.Count > 0)
            {
                if (entered_.Count == entered_.RemoveWhere(IsNull))
                {
                    outline.enabled = false;
                }
            }
        }
        /*
        void OnTriggerEnter(Collider collision)
        {
            
            if (collision.gameObject.tag.Equals("scanner"))
            {
                
                outline.enabled = true;
            }
            
        }
        */
        protected virtual void OnTriggerEnter(Collider other)
        {
            
            if (entered_.Count == 0)
            {
                outline.enabled = true;
            }
            entered_.Add(other);
        }
        /*
        void OnTriggerExit(Collider collision)
        {
            
            outline.enabled = false;
        }
        */
        protected virtual void OnTriggerExit(Collider other)
        {
            if (!entered_.Remove(other))
            {
                Debug.LogWarningFormat("{0} left {1} without first entering it");
            }
            else if (entered_.Count == 0)
            {
                outline.enabled = false;
            }
        }
    }
}