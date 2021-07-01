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
    public class SliderChangeColor : MonoBehaviour
    {
        [SerializeField]
        private Renderer TargetRenderer;

        public void OnSliderUpdatedRed(SliderEventData eventData)

        {
            
          
                transform.position = new Vector3((float)((eventData.NewValue*5)-2.5), transform.position.y, transform.position.z);
            
            
            
        }

        public void OnSliderUpdatedGreen(SliderEventData eventData)
        {
            transform.position = new Vector3(transform.position.x, (float)((eventData.NewValue * 5) - 2.5), transform.position.z);
        }

        public void OnSliderUpdateBlue(SliderEventData eventData)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (eventData.NewValue * 4)+1);
        }

        public void Scale_X(SliderEventData eventData)
        {
            transform.localScale = new Vector3(eventData.NewValue , transform.localScale.y, transform.localScale.z);
        }

        public void Scale_Y(SliderEventData eventData)
        {
            transform.localScale = new Vector3(transform.localScale.x, eventData.NewValue , transform.localScale.z);
        }

        public void Scale_Z(SliderEventData eventData)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, (float)((eventData.NewValue *0.2) ));
        }
      
    }
}
