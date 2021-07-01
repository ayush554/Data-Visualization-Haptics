//
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("Scripts/MRTK/Examples/SliderChangeColor")]
    public class plane : MonoBehaviour
    {
        public GameObject tool;
        [SerializeField]
        private Renderer TargetRenderer;

        public void OnSliderUpdatedRed(SliderEventData eventData)

        {


            tool.transform.position = new Vector3((float)((eventData.NewValue * 10) - 5), transform.position.y, transform.position.z);



        }

        public void OnSliderUpdatedGreen(SliderEventData eventData)
        {
            tool.transform.position = new Vector3(transform.position.x, eventData.NewValue * 5, transform.position.z);
        }

        public void OnSliderUpdateBlue(SliderEventData eventData)
        {
            tool.transform.position = new Vector3(transform.position.x, transform.position.y, eventData.NewValue * 5);
        }

        public void Scale_X(SliderEventData eventData)
        {
            tool.transform.localScale = new Vector3(eventData.NewValue * 5, transform.localScale.y, transform.localScale.z);
        }

        public void Scale_Y(SliderEventData eventData)
        {
            tool.transform.localScale = new Vector3(transform.localScale.x, eventData.NewValue * 5, transform.localScale.z);
        }

        public void Scale_Z(SliderEventData eventData)
        {
            tool.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, eventData.NewValue);
        }
        /* private Renderer TargetRenderer;

         public void OnSliderUpdatedRed(SliderEventData eventData)
         {
             TargetRenderer = GetComponentInChildren<Renderer>();
             if ((TargetRenderer != null) && (TargetRenderer.material != null))
             {
                 TargetRenderer.material.color = new Color(eventData.NewValue, TargetRenderer.sharedMaterial.color.g, TargetRenderer.sharedMaterial.color.b);
             }
         }

         public void OnSliderUpdatedGreen(SliderEventData eventData)
         {
             TargetRenderer = GetComponentInChildren<Renderer>();
             if ((TargetRenderer != null) && (TargetRenderer.material != null))
             {
                 TargetRenderer.material.color = new Color(TargetRenderer.sharedMaterial.color.r, eventData.NewValue, TargetRenderer.sharedMaterial.color.b);
             }
         }

         public void OnSliderUpdateBlue(SliderEventData eventData)
         {
             TargetRenderer = GetComponentInChildren<Renderer>();
             if ((TargetRenderer != null) && (TargetRenderer.material != null))
             {
                 TargetRenderer.material.color = new Color(TargetRenderer.sharedMaterial.color.r, TargetRenderer.sharedMaterial.color.g, eventData.NewValue);
             }
         }*/
    }
}
