using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    private static ToolManager _instance;
    public static ToolManager Instance => _instance ? _instance : FindObjectOfType<ToolManager>();
    // Start is called before the first frame update
    
    public bool toolModeEnabled;
    public GameObject baseTool;
    public GameObject trackingSpace;
    //public Material toolMaterial;
    [SerializeField]
    private GameObject attachedTool;
    void Start()
    {
        toolModeEnabled = false;
        //Old
        baseTool.transform.localEulerAngles = new Vector3(90, 0, 0);
        //baseTool.transform.localScale = new Vector3(.39f, .38f, .032f);
        //baseTool.transform.localPosition = new Vector3(.08f, .095f, 1.733f);
        //Modified
        baseTool.transform.localPosition = new Vector3(.08f, .095f, 1.8f);
        baseTool.transform.localScale = new Vector3(.4f, .4f, .032f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(toolModeEnabled && attachedTool == null && trackingSpace.transform.Find("Right_RiggedHandRight(Clone)/Palm Proxy Transform") != null)
        {
            AttachToolToHand();
        } else if (!toolModeEnabled && attachedTool != null)
        {
            Destroy(attachedTool);
        }
    }

    public void AttachToolToHand()
    {
        var rightPalm = trackingSpace.transform.Find("Right_RiggedHandRight(Clone)/Palm Proxy Transform");
        if(attachedTool != null)
        {
            Destroy(attachedTool);
        }
        GameObject newTool = Instantiate(baseTool, rightPalm);
        newTool.transform.SetParent(rightPalm.transform, false);
        attachedTool = newTool;
        attachedTool.SetActive(true);
        attachedTool.GetComponent<BoxCollider>().enabled = true;
        //newTool.GetComponent<MeshRenderer>().material = toolMaterial;
    }
    public void DetachAndFreezeTool()
    {
        if(attachedTool != null)
        {
            attachedTool.transform.parent = null;
        }
    }
    public GameObject GetAttachedTool()
    {
        return attachedTool;
    }
}
