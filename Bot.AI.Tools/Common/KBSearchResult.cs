using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;

namespace Bot.AI.Tools.KbSearch
{
    [SerializePropertyNamesAsCamelCase]
    public class KBSearchResult
    {
        public string Id { get; set; }

        [JsonProperty("cluster_en")]
        public string TopicEnglish { get; set; }

        [JsonProperty("cluster_ar")]
        public string TopicArabic { get; set; }

        [JsonProperty("answer_en")]
        public string AnswerEnglish { get; set; }

        [JsonProperty("answer_ar")]
        public string AnswerArabic { get; set; }

        public string[] Tags { get; set; }

    }
}