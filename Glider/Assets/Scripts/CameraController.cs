using System;
using UnityEngine;

namespace Assets.Scripts
{
    class CameraController : MonoBehaviour
    {
        [NonSerialized]
        public Transform targetGlider;

        public void Update()
        {
            if (targetGlider == null)
            {
                return;
            }

            Vector3 pos = new Vector3(targetGlider.position.x, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}
