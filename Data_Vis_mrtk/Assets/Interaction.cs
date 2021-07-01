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
    ///<summary>
    /// This class exists to route <see cref="Microsoft.MixedReality.Toolkit.UI.PressableButton"/> events through to <see cref="Microsoft.MixedReality.Toolkit.UI.Interactable"/>.
    /// The result is being able to have physical touch call Interactable.OnPointerClicked.
    ///</summary>

    [AddComponentMenu("Scripts/MRTK/SDK/PhysicalPressEventRouter")]
    public class Interaction : MonoBehaviour
    {
        public Collider box;
        public PressableButtonHoloLens2 interactable;
        public GameObject Datasets;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Transform t = Datasets.transform.Find("Lungs Transparent");
            Transform e = Datasets.transform.Find("HumanHead");
            Transform f = Datasets.transform.Find("Clustering Data");
            if (t.gameObject.activeSelf || e.gameObject.activeSelf || f.gameObject.activeSelf)
            {
                GetComponent<Collider>().enabled = true;
                interactable.enabled = true;
            }
            else
            {
                GetComponent<Collider>().enabled = false;
                interactable.enabled = false;
            }
        }
    }
}
