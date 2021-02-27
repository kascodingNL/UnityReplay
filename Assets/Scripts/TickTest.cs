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

        [SerializeField]
        TickCapturer tickCapturer;

        private void Awake()
        {
            tickCapturer = gameObject.AddComponent<TickCapturer>();
        }

        private void Start()
        {
            testObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            tickCapturer.RegisterGameObject(testObject);
        }

        private void FixedUpdate()
        {
            Debug.Log(tickCapturer.capturedTicks.Count);
        }

        private void OnApplicationQuit()
        {
            Debug.Log(tickCapturer.GenerateJson());
        }
    }
}
