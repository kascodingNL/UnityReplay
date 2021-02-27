using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace ReplaySystem
{
    [JsonObject]
    public class StorableObject
    {
        [JsonProperty]
        public int ObjectId;

        [JsonProperty]
        public float X;
        public float Y;
        [JsonProperty]
        public float Z;

        [JsonConstructor]
        public StorableObject(int ObjectId, float x, float y, float z)
        {
            this.ObjectId = ObjectId;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}