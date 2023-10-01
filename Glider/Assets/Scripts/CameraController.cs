using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class CameraController : MonoBehaviour
    {
        public Transform targetGlider;

        public void Update()
        {
            Vector3 pos = new Vector3(targetGlider.position.x, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}
