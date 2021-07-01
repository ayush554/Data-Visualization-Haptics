using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.Rendering.PostProcessing
{
    public class Volume_exploration : MonoBehaviour
    {
        public Material collision_Material;
        public Material original_material;
        public PostProcessVolume volume;
        public Text text;
        public Outline outline;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider collision)
        {

            if (collision.gameObject.tag.Equals("scanner"))
            {

                gameObject.GetComponent<MeshRenderer>().material = collision_Material;
                outline.enabled = true;
                volume.enabled = true;
                text.text = gameObject.name;
            }

        }
        void OnTriggerExit(Collider collision)
        {

            gameObject.GetComponent<MeshRenderer>().material = original_material;
            outline.enabled = false;
            volume.enabled = false;
            
        }
    }
}
