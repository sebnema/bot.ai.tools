using Bot.AI.Tools.KbSearch;
using System;
using System.Collections.Generic;

namespace Bot.AI.Tools.Helpers
{
    public class CommonHelper
    {
        public static IList<string> GetIndexes()
        {
            var azSearchClient = new AzureSearchClient();
            return azSearchClient.GetIndexNames();
        }

        public static string[] JoinArray(string[] array1, string[] array2)
        {
            if (array1 == null)
                return array2;

            if (array2 == null)
                return array1;

            string[] ret = new string[array1.Length + array2.Length];
            Array.ConstrainedCopy(array1, 0, ret, 0, array1.Length);
            Array.ConstrainedCopy(array2, 0, ret, array1.Length, array2.Length);
            return ret;
        }

    }


    public class DocDb
    {
        public const string KnowledgeBaseCollectionName = "curateditems";
    }
}
