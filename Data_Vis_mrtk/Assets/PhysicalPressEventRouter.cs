// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

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



namespace Microsoft.MixedReality.Toolkit.UI.BoundsControl
{
    ///<summary>
    /// This class exists to route <see cref="Microsoft.MixedReality.Toolkit.UI.PressableButton"/> events through to <see cref="Microsoft.MixedReality.Toolkit.UI.Interactable"/>.
    /// The result is being able to have physical touch call Interactable.OnPointerClicked.
    ///</summary>
    
    [AddComponentMenu("Scripts/MRTK/SDK/PhysicalPressEventRouter")]
    public class PhysicalPressEventRouter : MonoBehaviour
    {
        [Tooltip("Interactable to which the press events are being routed. Defaults to the object of the component.")]
        public Interactable routingTarget;
        public GameObject lungs;
        public GameObject Guardian;
        //private BoundsControl boundsControl;
        public Material transparent;
        public TextMeshPro displaymode;
        public TextMeshPro ModeChange;
        public GameObject Scanner;
        public GameObject search_Dataset;
        public GameObject Mainlungs;
        public GameObject Toolsmenu;
        public GameObject LargeMenu;
        public GameObject Datasets;
        public PressableButtonHoloLens2 interactable;
        public GameObject Trackingspace;
        public GameObject TrackingOrigin;
        public Material opaque;
        public GameObject Layers;
        public Mesh raycaster;
        public MeshRenderer scanner_mesh;
        public GameObject toolspace;
        public  static bool check = false;
        //public GameObject handRight;
        public GameObject cursor;
        private GameObject cursorvisual;
        private GameObject pointer2;
        private GameObject palm;
        private GameObject cursor_focus;
        private GameObject objectset;
        private GameObject tool;
        private GameObject r_hand;
        private bool near_far_check=true;
        public GameObject Skin;
        public GameObject skeleton;
        public GameObject muscle;
        public GameObject brain;

        public GameObject rightHandPrefab;

        [SerializeField]
        private GameObject frozenHand;
        private bool check_interaction_mode;
        /// Enum specifying which button event causes a Click to be raised.

        

        public enum PhysicalPressEventBehavior
        {
            EventOnClickCompletion = 0,
            EventOnPress,
            EventOnTouch
        }
        public PhysicalPressEventBehavior InteractableOnClick = PhysicalPressEventBehavior.EventOnClickCompletion;

        private void Awake()
        {
            if (routingTarget == null)
            {
                routingTarget = GetComponent<Interactable>();
            }
        }

        private bool CanRouteInput()
        {
            return routingTarget != null && routingTarget.IsEnabled;
        }

        
        /// <summary>
        /// Gets called when the TouchBegin event is invoked within the default PressableButton and 
        /// PressableButtonHoloLens2 components. When the physical touch with a 
        /// hand has begun, set physical touch state within Interactable. 
        /// </summary>
        public void OnHandPressTouched()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnTouch)
                {
                    routingTarget.HasPress = true;
                    routingTarget.TriggerOnClick();
                    routingTarget.HasPress = false;
                }
            }
        }

        /// <summary>
        /// Gets called when the TouchEnd event is invoked within the default PressableButton and 
        /// PressableButtonHoloLens2 components. Once the physical touch with a hand is removed, set
        /// the physical touch and possibly press state within Interactable.
        /// </summary>
        public void OnHandPressUntouched()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = false;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnTouch)
                {
                    routingTarget.HasPress = true;
                }
            }
        }

        /// <summary>
        /// Gets called when the ButtonPressed event is invoked within the default PressableButton and 
        /// PressableButtonHoloLens2 components. When the physical press with a hand is triggered, set 
        /// the physical touch and press state within Interactable. 
        /// </summary>
        public void OnHandPressTriggered()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {
                    //Debug.Log(transparent.name);
                    //Debug.Log(lungs.GetComponent<MeshRenderer>().material.name);

                    routingTarget.TriggerOnClick();
                    if(lungs.GetComponent<MeshRenderer>().material.name == "TransparentGray (Instance)")
                    {
                        displaymode.text = "Transparent";
                        lungs.GetComponent<MeshRenderer>().material = opaque;
                        
                    }
                    else 
                    {
                        displaymode.text = "Opaque";
                        lungs.GetComponent<MeshRenderer>().material = transparent;
                    }
                }
            }
        }
        public void OnHandPressTriggeredButton2()
        {
            if (CanRouteInput())
            {
                routingTarget.TriggerOnClick();
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {
                    Mainlungs = scandataset();
                    Transform t = Scanner.transform.Find("Tool");
                    tool = t.gameObject;
                    tool.transform.position = new Vector3(-0.027f, 0.095f, 1.27f);
                    tool.transform.localEulerAngles = new Vector3(90, 0, 0);
                    tool.transform.localScale = new Vector3(0.75f, 0.89f, 0.04f);
                    Transform[] allChildren1 = cursor.GetComponentsInChildren<Transform>(true);
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

                            if (child.gameObject.name == "Right_ShellHandRayPointer(Clone)")
                            {

                                //Scanner.SetActive(true);
                                pointer2 = child.gameObject;
                            
                            /*Transform obj1 = pointer2.transform.Find("Scanner");
                        Scanner = obj1.gameObject;*/
                            /*Scanner.transform.position = new Vector3(-0.07f, 0.122f, 1.3f);
                            Scanner.transform.localEulerAngles = new Vector3(0, 0, 0);
                            Scanner.transform.localScale = new Vector3(0.5f, 0.02f, 0.5f);
                            Scanner.transform.SetParent(pointer2.transform);
                            Mainlungs.transform.position = new Vector3(-0.22437f, -0.21430f, 1.05f);
                            Mainlungs.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                            check = true;*/
                            //cursorvisual.SetActive(false);
                            //Debug.Log("j5");
                            //Debug.Log("j5");
                            //Debug.Log(cursorvisual.activeSelf);

                        }
                        



                    }
                    
                    //Debug.Log("ON");
                    if (near_far_check)
                    {
                        near_far_check = false;
                        ModeChange.text = "Tool Interaction";
                        Scanner.SetActive(true);
                        displaymode.text = "Hand Touch";
                        Guardian.SetActive(false);
                        //tool.transform.position = new Vector3(-0.027f, 0.095f, 1.27f);
                        tool.transform.localEulerAngles = new Vector3(90, 0, 0);
                        //tool.transform.localScale = new Vector3(0.75f, 0.89f, 0.04f);

                        
                        //Scanner.transform.SetParent(pointer2.transform);
                        
                        //StartCoroutine("FarRoutine");
                       // Mainlungs.transform.position = new Vector3(-0.08577f, 0f, 1.05f);
                        Mainlungs.transform.localEulerAngles = new Vector3(0, 0, 0);
                        //Mainlungs.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        Mainlungs.SetActive(true);
                        tool.SetActive(true);

                        //tool.GetComponent<MeshRenderer>().enabled = true;
                        check = true;
                        //cursorvisual.SetActive(false);
                        Toolsmenu.SetActive(true);
                        LargeMenu.SetActive(false);
                        Layers.SetActive(false);
                        Guardian.SetActive(false);
                    }
                    else
                    {
                        near_far_check = true;
                        ModeChange.text = "Hand Interaction";
                        Scanner.SetActive(false);
                        displaymode.text = "Tool Touch";
                        //cursorvisual.SetActive(true);
                        cursor_focus.GetComponent<MeshFilter>().sharedMesh = raycaster;
                        cursor_focus.transform.localEulerAngles = new Vector3(-90, -90, 0);
                        cursor_focus.transform.localScale = new Vector3(50, 50, 50);
                       // StartCoroutine("NearRoutine");
                        
                        Mainlungs.transform.localEulerAngles = new Vector3(0, 0, 0);
                        //Mainlungs.transform.localScale = new Vector3(0.124f, 0.124f, 0.124f);
                        Mainlungs.SetActive(true);
                        check = false;
                        tool.SetActive(false);
                        Toolsmenu.SetActive(false);
                        LargeMenu.SetActive(false);
                        Layers.SetActive(false);
                        Guardian.SetActive(true);
                    }
                }
            }


            





        }
       /* IEnumerator FarRoutine()
        {
            Mainlungs = scandataset();
            //tool.transform.position = new Vector3(-0.027f, 0.095f, 1.27f);
            var targetPos = new Vector3(-0.027f, 0.095f, 1.27f);
            //Mainlungs.transform.position = new Vector3(-0.08577f, 0f, 0.024f);
            tool.SetActive(false);
            /*float speed = .8f;
            for (float i = .01f; i < 1.06f; i += .01f)
            {
                tool.SetActive(false);
                if (Mainlungs.transform.position.z < 1.06f)
                {
                    Mainlungs.transform.Translate(0f, 0.0f, speed * i);
                    yield return new WaitForSeconds(.05f);
                }
                else
                { break; }
            }*/
           /* while(Vector3.Magnitude(Mainlungs.transform.position - targetPos) > .1f)
            {
                Mainlungs.transform.position = Vector3.Lerp(Mainlungs.transform.position, targetPos, .1f);
                yield return new WaitForSeconds(.05f);
            }
            tool.SetActive(true);

        }
        IEnumerator NearRoutine()
        {
            Mainlungs = scandataset();
            var targetPos = new Vector3(Mainlungs.transform.position.x, Mainlungs.transform.position.y, Mainlungs.transform.position.z-1.2f);
            while (Vector3.Magnitude(Mainlungs.transform.position - targetPos) > .1f)
            {
                Mainlungs.transform.position = Vector3.Lerp(Mainlungs.transform.position, targetPos, .1f);
                yield return new WaitForSeconds(.05f);
            }
            Guardian.SetActive(true);
        }*/
        public void checkplane()
        {

            check_interaction_mode = false;
           Transform[] space = Trackingspace.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in space)
            {

                if (child.gameObject.name == "Right_RiggedHandRight(Clone)")

                {
                    palm = child.gameObject;
                }
            }
            Transform[] righthand = palm.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in righthand)
            {

                if (child.gameObject.name == "Palm Proxy Transform")

                {
                    palm = child.gameObject;
                }
                if (child.gameObject.name == "R_Hand")

                {
                    r_hand = child.gameObject;
                }
            }
            Transform e = palm.transform.Find("Tool");
            if (e)
            {
                /*foreach (Collider col in UnityEngine.Physics.OverlapBox(e.position, e.localScale * .5f, e.rotation))
                {
                    col.GetComponent<Outline>().enabled = false;
                    Debug.Log(col.name);

                }*/
                Destroy(e.gameObject);
            }
            Transform t = Scanner.transform.Find("Tool");
            tool = t.gameObject;
            if(Toolsmenu.activeSelf)
            { tool.SetActive(true); }
            else
            {
                tool.SetActive(false);
            }
            tool.transform.SetParent(toolspace.transform);
            tool.transform.position = new Vector3(-0.027f, 0.095f, 1.27f);
            tool.transform.localEulerAngles = new Vector3(90, 0, 0);
            tool.GetComponent<MeshRenderer>().material = opaque;
            r_hand.GetComponent<SkinnedMeshRenderer>().material = opaque;

        }

        public void ToggleToolTouch()
        {
            if (!ToolManager.Instance.toolModeEnabled)
            {
                ActivateToolTouch();
            } else
            {
                DeactivateToolTouch();
            }        
        }
        public void ActivateToolTouch()
        {
            ToolManager.Instance.toolModeEnabled = true;
            displaymode.text = "Hand Touch";
            Guardian.SetActive(false);

        }
        public void DeactivateToolTouch()
        {
            ToolManager.Instance.toolModeEnabled = false;
            displaymode.text = "Tool Touch";
            Guardian.SetActive(true);
        }
        //Locks the tool or right hand in position, depending on mode
        public void FreezeAppendage()
        {
            if (ToolManager.Instance.toolModeEnabled)
            {
                ToolManager.Instance.DetachAndFreezeTool();
            }
            else
            {
                Transform currentRightHand = Trackingspace.transform.Find("Right_RiggedHandRight(Clone)");

                if (currentRightHand != null && StudyTimer.Instance.HasStarted())
                {
                    var targetPosition = TrackingOrigin.transform.Find("LeapHandController/RigidRoundHand_R(Clone)/palm").position;
                    targetPosition.z -= .05f;
                    targetPosition.x += .005f;
                    frozenHand = Instantiate(rightHandPrefab, targetPosition, Quaternion.Euler(new Vector3(180f, 90f, 0f)));
                   
                    frozenHand.tag = "TempHand";
                }
            }
        }
        public void UnfreezeAppendage()
        {
            if (frozenHand != null)
            {
                Destroy(frozenHand);
            }
            if (ToolManager.Instance.toolModeEnabled)
            {
                ToolManager.Instance.AttachToolToHand();
            } else
            {
               
            }
        }
        public void DisableDatasetCollider()
        {
            var activeSet = scandataset();
            activeSet.GetComponent<BoxCollider>().enabled = false;
        }
        public void EnableDatasetCollider()
        {
            var activeSet = scandataset();
            activeSet.GetComponent<BoxCollider>().enabled = true;
        }
       /* IEnumerator Growlungs()
        {
            Transform t = Datasets.transform.Find("Lungs Transparent");
            for (float i = .01f; i < .18f; i += .01f)
            {
                t.localScale = new Vector3(i, i, i);
                t.gameObject.SetActive(true);
                yield return new WaitForSeconds(.05f);
            }
            Layers.SetActive(false);
        }
        IEnumerator Growskull()
        {
            Transform e = Datasets.transform.Find("HumanHead");
            for (float i = .1f; i < .924f; i += .05f)
            {
                e.localScale = new Vector3(i, i, i);
                e.gameObject.SetActive(true);
                yield return new WaitForSeconds(.05f);
            }
            Layers.SetActive(true);
            LargeMenu.SetActive(false);
        }
        IEnumerator Growcluster()
        {
            Transform f = Datasets.transform.Find("Clustering Data");
            for (float i = .01f; i < .1f; i += .01f)
            {
                f.localScale = new Vector3(i, i, i);
                f.gameObject.SetActive(true);
                yield return new WaitForSeconds(.05f);
            }
            Layers.SetActive(false);
        }

        IEnumerator shrinkcluster()
        {
            Transform f = Datasets.transform.Find("Clustering Data");
            
            
           
                while (f.localScale.x > .01f)
                {
                    f.localScale = Vector3.Lerp(f.localScale, new Vector3(0, 0, 0), .2f);
                    yield return new WaitForSeconds(.05f);
                }
                f.gameObject.SetActive(false);
                yield return null;
            
            


        }
        IEnumerator shrinkskull()
        {
            Transform e = Datasets.transform.Find("HumanHead");
            while (e.localScale.x > .01f)
            {
                e.localScale = Vector3.Lerp(e.localScale, new Vector3(0, 0, 0), .2f);
                yield return new WaitForSeconds(.05f);
            }
            e.gameObject.SetActive(false);
            yield return null;
        }
        IEnumerator shrinklungs()
        {
            Transform t = Datasets.transform.Find("Lungs Transparent");
            while (t.localScale.x > .01f)
            {
                t.localScale = Vector3.Lerp(t.localScale, new Vector3(0, 0, 0), .2f);
                yield return new WaitForSeconds(.05f);
            }
            t.gameObject.SetActive(false);
            yield return null;
        }
       */
        public void spawnlungs()
        {
            Layers.SetActive(false);


        }
        public void skull()
        {

            Layers.SetActive(true);
            LargeMenu.SetActive(false);

        }
        public void cluster()
        {
            Layers.SetActive(false);


        }
        public void selectdataset()
        {
            Transform[] space = search_Dataset.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in space)
            {
                if (child.gameObject.name == "Lungs" && child.gameObject.activeSelf)
                {
                    Transform t = Datasets.transform.Find("Lungs Transparent");
                    Transform e = Datasets.transform.Find("HumanHead");
                    Transform f = Datasets.transform.Find("Clustering Data");
                    
                    t.gameObject.SetActive(true);
                    e.gameObject.SetActive(false);
                    f.gameObject.SetActive(false);
                }
                else if (child.gameObject.name == "Skull1" && child.gameObject.activeSelf)
                {
                   
                        
                        Transform t = Datasets.transform.Find("Lungs Transparent");
                        Transform e = Datasets.transform.Find("HumanHead");
                        Transform f = Datasets.transform.Find("Clustering Data");
                        t.gameObject.SetActive(false);
                        e.gameObject.SetActive(true);
                        f.gameObject.SetActive(false);
                }
                    else if (child.gameObject.name == "Cluster" && child.gameObject.activeSelf)
                {
                        
                            
                            Transform t = Datasets.transform.Find("Lungs Transparent");
                            Transform e = Datasets.transform.Find("HumanHead");
                            Transform f = Datasets.transform.Find("Clustering Data");
                            t.gameObject.SetActive(false);
                            e.gameObject.SetActive(false);
                            f.gameObject.SetActive(true);
                }

                    
                    
                

            }
        }
       void Update()
       {
            
            if (check_interaction_mode)
            {
                Transform[] space = Trackingspace.GetComponentsInChildren<Transform>(true);
                foreach (Transform child in space)
                {

                    if (child.gameObject.name == "Right_RiggedHandRight(Clone)")

                    {
                        palm = child.gameObject;
                        Transform[] righthand = palm.GetComponentsInChildren<Transform>(true);
                        foreach (Transform child2 in righthand)
                        {
                            if (child2.gameObject.name == "Palm Proxy Transform")

                            {
                                palm = child2.gameObject;
                                Transform e = palm.transform.Find("Tool");
                                if (!e)
                                {
                                    Debug.Log("plane");
                                }
                            }
                            
                        }
                    }
                    
                }
               
                

            }

        }
        public void connectplane()
        {
            check_interaction_mode = true;
            Transform[] space = Trackingspace.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in space)
            {

                if (child.gameObject.name == "Right_RiggedHandRight(Clone)")

                {
                    palm = child.gameObject;
                }
                if (child.gameObject.name == "R_Hand")

                {
                    r_hand = child.gameObject;
                }
            }
            Transform[] righthand = palm.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in righthand)
            {
                if (child.gameObject.name == "Palm Proxy Transform")

                {
                    palm = child.gameObject;
                }
            }

            Transform e = palm.transform.Find("Tool");
            

            if (e)
            {
                Destroy(e.gameObject);
            }
            Transform t = Scanner.transform.Find("Tool");
            tool = t.gameObject;
            GameObject dataPoint = Instantiate(tool, tool.transform.position, Quaternion.identity);
            //dataPoint.SetActive(false);
            dataPoint.name = "Tool";
            dataPoint.transform.SetParent(palm.transform,false);
            //Scanner.transform.position = new Vector3(0f, 0f, 1.3f);
            dataPoint.transform.localEulerAngles = new Vector3(90, 0, 0);
            dataPoint.GetComponent<MeshRenderer>().material = transparent;
            r_hand.GetComponent<SkinnedMeshRenderer>().material = transparent;
            tool.SetActive(false);

            


        }




        public void OnHandPressTriggeredButton3()
        {
            if (CanRouteInput())
            {
                Mainlungs = scandataset();
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {
                    BoundsControl boundsControl = Mainlungs.GetComponent<BoundsControl>();
                    ObjectManipulator obj = Mainlungs.GetComponent<ObjectManipulator>();
                    routingTarget.TriggerOnClick();
                    if (obj.enabled == true)
                    {
                        
                        
                        /* boundsControl.RotationHandlesConfig.ShowRotationHandleForX=true;
                         boundsControl.RotationHandlesConfig.ShowRotationHandleForY = true;
                         boundsControl.RotationHandlesConfig.ShowRotationHandleForZ = true;*/
                        boundsControl.enabled = true;
                        obj.enabled = false;
                        displaymode.text = "Unlock";
                    }
                    else 
                    {
                        
                        /* boundsControl.RotationHandlesConfig.ShowRotationHandleForX =false;
                         boundsControl.RotationHandlesConfig.ShowRotationHandleForY = false;
                         boundsControl.RotationHandlesConfig.ShowRotationHandleForZ = false;*/
                        boundsControl.enabled = false;
                        obj.enabled = true;
                        displaymode.text = "Lock";

                    }
                }
                
            }
        }
        public void OnHandPressTriggeredButton4()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {
                    
                    routingTarget.TriggerOnClick();
                    if (LargeMenu.activeSelf)
                    {
                        Toolsmenu.SetActive(false);
                        LargeMenu.SetActive(false);
                        Layers.SetActive(false);
                    }
                    else
                    {
                        Toolsmenu.SetActive(false);
                        LargeMenu.SetActive(true);
                        Scanner.SetActive(false);
                        Layers.SetActive(false);
                    }
                    
                }
            }
        }
        public void skin()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {

                    routingTarget.TriggerOnClick();
                    if (Skin.activeSelf)
                    {
                        Skin.SetActive(false);
                    }
                    else
                    {
                        Skin.SetActive(true);
                    }

                }
            }
        }
        public void Muscle()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {

                    routingTarget.TriggerOnClick();
                    if (muscle.activeSelf)
                    {
                        muscle.SetActive(false);
                    }
                    else
                    {
                        muscle.SetActive(true);
                    }

                }
            }
        }
        public void Skeleton()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {

                    routingTarget.TriggerOnClick();
                    if (skeleton.activeSelf)
                    {
                        skeleton.SetActive(false);
                    }
                    else
                    {
                        skeleton.SetActive(true);
                    }

                }
            }
        }

        public void Brain()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {

                    routingTarget.TriggerOnClick();
                    if (brain.activeSelf)
                    {
                        brain.SetActive(false);
                    }
                    else
                    {
                        brain.SetActive(true);
                    }

                }
            }
        }
        public void focusSkin()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {

                    routingTarget.TriggerOnClick();
                    Skin.SetActive(true);
                    muscle.SetActive(false);
                    skeleton.SetActive(false);

                }
            }
        }
        public void focusMuscle()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {

                    routingTarget.TriggerOnClick();
                    Skin.SetActive(false);
                    muscle.SetActive(true);
                    skeleton.SetActive(false);

                }
            }
        }
        public void focusSkull()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnPress)
                {

                    routingTarget.TriggerOnClick();
                    Skin.SetActive(false);
                    muscle.SetActive(false);
                    skeleton.SetActive(true);

                }
            }
        }
        /// <summary>
        /// Gets called when the ButtonReleased event is invoked within the default PressableButton and 
        /// PressableButtonHoloLens2 components.  Once the physical press with a hand is completed, set
        /// the press and physical touch states within Interactable
        /// </summary>
        public void OnHandPressCompleted()
        {
            if (CanRouteInput())
            {
                routingTarget.HasPhysicalTouch = true;
                routingTarget.HasPress = true;
                if (InteractableOnClick == PhysicalPressEventBehavior.EventOnClickCompletion)
                {
                    routingTarget.TriggerOnClick();
                }
                routingTarget.HasPress = false;
                routingTarget.HasPhysicalTouch = false;
            }
        }
        public GameObject scandataset()
        {
            Transform t = Datasets.transform.Find("Lungs Transparent");
            Transform e = Datasets.transform.Find("HumanHead");
            Transform f = Datasets.transform.Find("Clustering Data");
            if(t.gameObject.activeSelf)
            {
                Mainlungs = t.gameObject;
            }
            if (e.gameObject.activeSelf)
            {
                Mainlungs = e.gameObject;
            }
            if (f.gameObject.activeSelf)
            {
                Mainlungs = f.gameObject;
            }
            return Mainlungs;
        }

    }
}