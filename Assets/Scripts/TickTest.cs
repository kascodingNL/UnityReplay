using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class TickTest : MonoBehaviour
    {
        public GameObject testObject;

        private void Start()
        {
            testObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
    }
}
