using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

using Bot.AI.Tools.Interfaces;
using System;
using System.Collections.Generic;

namespace Bot.AI.Tools.KbSearch
{
    [Serializable]
    public class AzureSearchClient : IAzureSearchClient
    {
        private readonly string searchServiceName = ConfigurationManager.AppSettings["Search:ServiceName"];
        private readonly string queryApiKey = ConfigurationManager.AppSettings["Search:ApiKey"];
        private readonly string searchIndexName = ConfigurationManager.AppSettings["Search:IndexName"];
        private static SearchIndexClient _indexClient = null;

        public AzureSearchClient() { }

        public AzureSearchClient(string indexName)
        {
            if (!string.IsNullOrEmpty(indexName))
                searchIndexName = indexName;
        }

        public IList<string> GetIndexNames()
        {
            var searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(queryApiKey));
            var list = searchClient.Indexes.ListNames();
            return list.ToList();
        }

        public async void RunIndexer(string indexName)
        {
            var searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(queryApiKey));
            var indexerName = (from i in searchClient.Indexers.List().Indexers
                               where i.TargetIndexName == indexName
                               select i.Name).FirstOrDefault();

            if (!string.IsNullOrEmpty(indexerName))
            {
                await searchClient.Indexers.RunAsync(indexerName);
            }
        }

        public async Task<DocumentSearchResult<KBSearchResult>> GetSearchResults(string q, string searchFields = "")
        {
            if (_indexClient == null)
            {
                _indexClient = new SearchIndexClient(searchServiceName, searchIndexName, new SearchCredentials(queryApiKey));
            }

            SearchParameters searchParams = null;

            if (!string.IsNullOrEmpty(searchFields))
            {
                searchParams = new SearchParameters() { SearchFields = searchFields?.Split(',')?.ToArray() };
            }

            var searchResult = await _indexClient?.Documents?.SearchAsync<KBSearchResult>(q, searchParams);

            return searchResult;
        }
    }

}