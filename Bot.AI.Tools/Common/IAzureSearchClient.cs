using Bot.AI.Tools.KbSearch;
using Microsoft.Azure.Search.Models;
using System.Threading.Tasks;


namespace Bot.AI.Tools.Interfaces
{
    public interface IAzureSearchClient
    {
         Task<DocumentSearchResult<KBSearchResult>> GetSearchResults(string q, string searchFields = "");
        void RunIndexer(string indexName);
    }
}