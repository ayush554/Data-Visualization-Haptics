
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI.BoundsControlTypes;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Experimental.Physics;

namespace Microsoft.MixedReality.Toolkit.UI.BoundsControl
{
    public class check_script : MonoBehaviour
    {


        public GameObject cursor;
        public GameObject Trackingspace;
        private GameObject cursorvisual;
        private GameObject cursor_focus;
        public GameObject Scanner;
        private GameObject pointer2;
        public PhysicalPressEventRouter checker;
        public GameObject transform_scanner;
        public MeshRenderer scanner_mesh;
        //private bool check = checker.check;
        private bool check=false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            /*check = PhysicalPressEventRouter.check;
            Debug.Log(check);

            /* Transform[] allChildren1 = cursor.GetComponentsInChildren<Transform>(true);
             foreach (Transform child in allChildren1)
             {
                 if (child.gameObject.name == "CursorVisual")
                 {
                     cursorvisual = child.gameObject;

                 }
                 if (child.gameObject.name == "CursorFocus")
                 {
                     cursor_focus = child.gameObject;
                 }
             }


            Transform[] space = Trackingspace.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in space)
            {
                //Debug.Log(child.gameObject.name);
                if (child.gameObject.name == "Right_ShellHandRayPointer(Clone)")
                {
                    

                    pointer2 = child.gameObject;
                    if (check)
                    {
                        
                        Scanner.transform.position = new Vector3(0,0,1);
                        Scanner.transform.localEulerAngles = new Vector3(0, 0, 0);
                        Scanner.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        scanner_mesh.enabled = true;
                        Scanner.transform.SetParent(pointer2.transform);
                    }

                }

            }*/
        }
    }
}
