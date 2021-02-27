using Newtonsoft.Json;
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

        public Replay replay { get; private set; }

        public bool Replaying;


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
            if (!Replaying)
            {
                Dictionary<int, StorableObject> convertedObjects = new Dictionary<int, StorableObject>();

                foreach (var iteration in subscribedGameObjects)
                {
                    convertedObjects.Add(iteration.Key, new StorableObject(iteration.Key, iteration.Value.transform.position.x, iteration.Value.transform.position.y, iteration.Value.transform.position.z));
                }

                StorableTick tickData = new StorableTick(convertedObjects);

                capturedTicks.Add(Tick, tickData);
            }
            else
            {

            }
            Tick++;
        }

        public string GenerateJson(Formatting formatting = Formatting.None)
        {
            replay = new Replay(new ReplayInfo(Time.fixedDeltaTime, (long)UnityEngine.Random.Range(uint.MinValue, int.MaxValue)), capturedTicks);

            return Newtonsoft.Json.JsonConvert.SerializeObject(replay, formatting);
        }

        public void ImportReplay(string JsonReplay)
        {
            replay = JsonConvert.DeserializeObject<Replay>(JsonReplay);
        }
    }

    [JsonObject]
    class Replay
    {
        [JsonProperty]
        public ReplayInfo ReplayInfo;

        [JsonProperty]
        public Dictionary<ulong, StorableTick> ticks;

        [JsonConstructor]
        public Replay(ReplayInfo info, Dictionary<ulong, StorableTick> data)
        {
            this.ReplayInfo = info;
            this.ticks = data;
        }
    }

    [JsonObject]
    class ReplayInfo
    {
        [JsonProperty]
        public float TimeStep;

        [JsonProperty]
        public long MatchId;

        [JsonConstructor]
        public ReplayInfo(float TimeStep, long MatchId)
        {
            this.TimeStep = TimeStep;
            this.MatchId = MatchId;
        }
    }
}