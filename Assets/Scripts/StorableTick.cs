using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaySystem
{
    [JsonObject]
    public class StorableTick
    {
        [JsonProperty]
        public Dictionary<int, StorableObject> StorableObjectsData = new Dictionary<int, StorableObject>();

        [JsonConstructor]
        public StorableTick(Dictionary<int, StorableObject> data)
        {
            this.StorableObjectsData = data;
        }
    }
}
