using Newtonsoft.Json;

namespace Bot.AI.Tools.Common
{
    public class CuratedKBResult
    {
        [JsonProperty("id")]
        public string DocId { get; set; }
        [JsonProperty("kbId")]
        public string KbId { get; set; }

        [JsonProperty(PropertyName = "isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty(PropertyName = "clusters")]
        public Topic[] Topics { get; set; }

        [JsonProperty(PropertyName = "answers")]
        public AnswerItem[] Answers { get; set; }

        [JsonProperty(PropertyName = "actions")]
        public ActionItem[] Actions { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("tags_ar")]
        public string[] TagsArabic { get; set; }
    }

    public class Topic
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class AnswerItem
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class ActionItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("client")]
        public string Client { get; set; }
        [JsonProperty("channels")]
        public string[] Channels { get; set; }
        [JsonProperty("values")]
        public ActionValue[] Values { get; set; }
    }

    public class ActionValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
