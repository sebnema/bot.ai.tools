using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bot.AI.Tools
{
    public class Value
    {
        public string entity { get; set; }
        public string type { get; set; }
        public double score { get; set; }
    }

    public class Parameter
    {
        public string name { get; set; }
        public bool required { get; set; }
        public List<Value> value { get; set; }
    }

    public class Action
    {
        public bool triggered { get; set; }
        public string name { get; set; }
        public List<Parameter> parameters { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public double score { get; set; }
        public List<Action> actions { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public double score { get; set; }
    }

    public class RootObject
    {
        public string query { get; set; }
        public List<Intent> intents { get; set; }
        public List<Entity> entities { get; set; }
    }

    public class UtteranceModel
    {
        [JsonProperty("text")]
        public string Utterance { get; set; }

        [JsonProperty("intentName")]
        public string IntentName { get; set; }
        
        [JsonProperty("entityLabels")]
        public EntityLabel[] EntityLabels { get; set; }
    }


    public class EntityLabel
    {
        [JsonProperty("entityName")]
        public string Entity { get; set; }

        [JsonProperty("startCharIndex")]
        public int StartIndex { get; set; }

        [JsonProperty("endCharIndex")]
        public int EndIndex { get; set; }
    }
}
