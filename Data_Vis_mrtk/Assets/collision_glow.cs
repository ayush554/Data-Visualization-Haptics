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
    public class collision_glow : MonoBehaviour
    {
        public Material default_material;
        public Material glow_material;
        public PostProcessVolume volume;
        private MeshRenderer meshRend;
        // Start is called before the first frame update
        void Start()
        {
            meshRend = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter( Collider collision)
        {
            Debug.Log("H");
            if (collision.gameObject.tag.Equals("datapoints"))
            {
                meshRend.material = glow_material;
                volume.enabled=true;
            }
        }
        void OnTriggerExit(Collider collision)
        {
            meshRend.material = default_material;
            volume.enabled = false;
        }
    }
}