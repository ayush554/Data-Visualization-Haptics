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
            transform.position = new Vector3(eventData.NewValue * 2, transform.position.y, transform.position.z);
        }

        public void OnSliderUpdatedGreen(SliderEventData eventData)
        {
            transform.position = new Vector3(transform.position.x, eventData.NewValue * 2, transform.position.z);
        }

        public void OnSliderUpdateBlue(SliderEventData eventData)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, eventData.NewValue * 2);
        }
    }
}
