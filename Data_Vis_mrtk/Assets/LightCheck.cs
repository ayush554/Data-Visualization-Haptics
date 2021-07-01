using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Microsoft.MixedReality.Toolkit.Utilities
{
    /// <summary>
    /// Utility component to animate and visualize a light that can be used with 
    /// the "MixedRealityToolkit/Standard" shader "_HoverLight" feature.
    /// </summary>
    [ExecuteInEditMode]
    [HelpURL("https://docs.microsoft.com/windows/mixed-reality/mrtk-unity/features/rendering/hover-light")]
    [AddComponentMenu("Scripts/MRTK/Core/LightCheck")]
    public class LightCheck : MonoBehaviour
    {
        public GameObject cursor;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(cursor.GetComponent<MeshFilter>().sharedMesh.name == "Cursor_Focus")
            {
                GetComponent<HoverLight>().Radius=0.1f;
            }
            else
            {
                GetComponent<HoverLight>().Radius=0.5f;
            }
        }
    }
}