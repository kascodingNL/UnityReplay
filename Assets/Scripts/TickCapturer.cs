using ReplaySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class TickCapturer : MonoBehaviour
    {
        public Dictionary<int, GameObject> subscribedGameObjects;

        public Dictionary<ulong, StorableTick> capturedTicks;

        private void Start()
        {
            subscribedGameObjects = new Dictionary<int, GameObject>();
            capturedTicks = new Dictionary<ulong, StorableTick>();
        }

        public void RegisterGameObject(GameObject toSubscribe)
        {
            if (!subscribedGameObjects.ContainsValue(toSubscribe))
                subscribedGameObjects.Add(subscribedGameObjects.Count, toSubscribe);
            else
                Debug.LogError("Object already existed in subcribed object list!");
        }

        private void FixedUpdate()
        {
            Dictionary<int, StorableObject> convertedObjects = new Dictionary<int, StorableObject>();

            foreach(var iteration in subscribedGameObjects)
            {
                if(!convertedObjects.ContainsKey(iteration.Key))
                {
                    convertedObjects.Add(iteration.Key, new StorableObject(iteration.Key, iteration.Value.transform.position.x, iteration.Value.transform.position.y, iteration.Value.transform.position.z));
                }
            }
        }
    }
}
