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
        private Dictionary<int, GameObject> subscribedGameObjects = new Dictionary<int, GameObject>();

        public Dictionary<ulong, StorableTick> capturedTicks { get; private set; }

        [SerializeField]
        public ulong Tick { get; private set; }

        private void Awake()
        {
            //subscribedGameObjects = new Dictionary<int, GameObject>();
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

            foreach (var iteration in subscribedGameObjects)
            {
                convertedObjects.Add(iteration.Key, new StorableObject(iteration.Key, iteration.Value.transform.position.x, iteration.Value.transform.position.y, iteration.Value.transform.position.z));
            }

            StorableTick tickData = new StorableTick(convertedObjects);

            capturedTicks.Add(Tick, tickData);
            Tick++;
        }

        public string GenerateJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(capturedTicks);
        }
    }
}
