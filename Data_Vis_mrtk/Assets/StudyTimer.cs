using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class StudyTimer : MonoBehaviour
{
    private static StudyTimer _instance;
    public static StudyTimer Instance => _instance ? _instance : FindObjectOfType<StudyTimer>();

    public GameObject Trackingorigin;
    private float startTime;
    private float elapsedTime;
    private bool hasStarted = false;

    private bool isPaused;
    private bool frozenHandExists;
    public LayerMask rayCastTargetsWithHand;
    public LayerMask rayCastTargets;

    public void StartTimer()
    {
        startTime = Time.time;
        elapsedTime = 0f;
        hasStarted = true;
        isPaused = false;
    }
    public void PauseTimer()
    {
        if (!isPaused)
        {
            elapsedTime += Time.time - startTime;
            isPaused = true;
        }
    }
    public void ResumeTimer()
    {
        startTime = Time.time;
        isPaused = false;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeTimer();
        } else
        {
            PauseTimer();
        }
    }
    public bool HasStarted()
    {
        return hasStarted;
    }

    public void EndTimerCluster(string cluster)
    {
        float endTime = Time.time;
        //Elapsed time should be in seconds
        float elapsedTime = endTime - startTime;
        //Write to the file
        string dataPath = Application.dataPath + "/" + "Timer_Results.csv";
        StreamWriter writer = new StreamWriter(dataPath, true);

        if (new FileInfo(dataPath).Length == 0)
        {
            // file is empty
            writer.WriteLine("Elapsed Time (seconds),Cluster Chosen");
        }

        writer.WriteLine(elapsedTime + "," + cluster);
        writer.Flush();
        writer.Close();

        Application.Quit();
    }
    public void EndTimerTissue()
    {
        float endTime = Time.time;
        //Elapsed time should be in seconds
        float elapsedTime = endTime - startTime;
        //Write to the file
        string dataPath = Application.dataPath + "/" + "Timer_Results.csv";
        StreamWriter writer = new StreamWriter(dataPath, true);

        if (new FileInfo(dataPath).Length == 0)
        {
            // file is empty
            writer.WriteLine("Elapsed Time (seconds),Tissue Chosen");
        }

        writer.WriteLine(elapsedTime + "," + ClusterTracker.Instance.GetMostRecentValue());
        writer.Flush();
        writer.Close();

        Application.Quit();
    }
   
    public void EndTimerHead()
    {
        //Should be paused before running this function, so elapsed time is properly updated

        
        var distanceData = CalculateDistanceFromScar();
        //Write to the file
        string dataPath = Application.dataPath + "/" + "Timer_Results.csv";
        StreamWriter writer = new StreamWriter(dataPath, true);

        if (new FileInfo(dataPath).Length == 0)
        {
            // file is empty
            writer.WriteLine("Elapsed Time (seconds),Mode,TotalDistanceFromScar, DeltaX, DeltaY, DeltaZ");
        }

        writer.WriteLine(elapsedTime + "," + (ToolManager.Instance.toolModeEnabled ? "Haptic Plane" : "Visual + Haptic") + "," + distanceData[0] + "," + distanceData[1] + "," + distanceData[2] + "," + distanceData[3]);
        writer.Flush();
        writer.Close();

        Application.Quit();
    }

    /*      ###FORMAT###
     *  [0] - Total Distance
     *  [1] - Difference in X
     *  [2] - Difference in Y
     *  [3] - Difference in Z
     * 
     */
    float[] CalculateDistanceFromScar()
    {
        
        //Calculate the distance between hand/tool and scar
        float distance;
        float deltaX;
        float deltaY;
        float deltaZ;
        var scar = GameObject.FindGameObjectsWithTag("scar")[0];
        if (ToolManager.Instance.toolModeEnabled)
        {
            //Since tool is rotated by x = 90, distance should be done from z axis
            var tool = ToolManager.Instance.GetAttachedTool();
            //Find the direction from scar to tool
            var dir = Vector3.Normalize(tool.transform.position - scar.transform.position);
            //Raycast origin point should be edge of scar sphere collider
            var originOffset = dir * (scar.GetComponent<SphereCollider>().radius * scar.transform.lossyScale.x);
            var origin = scar.transform.position + originOffset;
            //Send out a raycast, will not hit target if its already inside (colliders are touching)
            RaycastHit hit;
            if(Physics.Raycast(origin, dir, out hit, Mathf.Infinity, rayCastTargets, QueryTriggerInteraction.Collide))
            {
                distance = hit.distance;
                deltaX = Mathf.Abs(hit.point.x - origin.x);
                deltaY = Mathf.Abs(hit.point.y - origin.y);
                deltaZ = Mathf.Abs(hit.point.z - origin.z);
            } else
            {
                //Didn't hit means raycast started inside tool, distance is zero
                distance = 0f;
                deltaX = 0f; deltaY = 0f; deltaZ = 0f;
            }
        }
        else
        {
            //Get frozen hand, if that doesn't exist see if the right hand currently exists
            var handCheck = GameObject.FindGameObjectsWithTag("TempHand");
            GameObject hand = null;
            Transform palm;
            if (handCheck.Length <= 0)
            {
                frozenHandExists = false;
                palm = GameObject.Find("UltrahapticsKit (1)/TrackingOrigin/LeapHandController/RigidRoundHand_R(Clone)/palm").transform;
            } else
            {
                frozenHandExists = true;
                hand = handCheck[0];
                palm = hand.transform.Find("R_Hand_MRTK_Rig/R_Wrist/palm");
            }
            Debug.Log(palm);
            var palmBox = palm.GetComponent<BoxCollider>();
            //Direction between cetners
            var dir = Vector3.Normalize(palmBox.transform.position - scar.transform.position);
            //Raycast origin point should be edge of scar sphere collider
            var originOffset = dir * (scar.GetComponent<SphereCollider>().radius * scar.transform.lossyScale.x);
            var origin = scar.transform.position + originOffset;
            //Send out a raycast, will not hit target if its already inside (colliders are touching)
            RaycastHit hit;
            if (Physics.Raycast(origin, dir, out hit, Mathf.Infinity, (frozenHandExists ? rayCastTargets : rayCastTargetsWithHand), QueryTriggerInteraction.Collide))
            {
                distance = hit.distance;
                deltaX = Mathf.Abs(hit.point.x - origin.x);
                deltaY = Mathf.Abs(hit.point.y - origin.y);
                deltaZ = Mathf.Abs(hit.point.z - origin.z);
            }
            else
            {
                //Didn't hit means raycast started inside tool, distance is zero
                distance = 0f;
                deltaX = 0f; deltaY = 0f; deltaZ = 0f;
            }
        }
        //Multiply distance by head scale to normalize accross different sizes (not currently used since scale is now static)
        //distance *= GameObject.Find("HumanHead").transform.lossyScale.x;
        return new float[] { distance, deltaX, deltaY, deltaZ };
    }
}
