using System;
using System.Configuration;
using System.Linq;
using Microsoft.Azure.Documents.Client;

using System.Collections.Generic;
using Bot.AI.Tools.Common;
using System.Threading.Tasks;
using Bot.AI.Tools.Helpers;

namespace Bot.AI.Tools.DocDB
{
    [Serializable]
    public class DocDbClient
    {
        private readonly string docDbEndpointUri = ConfigurationManager.AppSettings["KBDocDb:EndpointUri"];
        private readonly string docDbPrimaryKey = ConfigurationManager.AppSettings["KBDocDb:AuthKey"];
        private readonly string databaseName = ConfigurationManager.AppSettings["KBDocDb:Databasename"];
        private readonly string collectionName = DocDb.KnowledgeBaseCollectionName;

        private static DocumentClient _client;

        public CuratedKBResult GetDocById(string docId)
        {
            if (_client == null)
            {
                _client = new DocumentClient(new Uri(docDbEndpointUri), docDbPrimaryKey);
            }

            var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);

            CuratedKBResult kbQueryItem = _client.CreateDocumentQuery<CuratedKBResult>(collectionLink)
                                            .Where(so => so.DocId == docId && !so.IsDeleted)
                                            .AsEnumerable()
                                            .FirstOrDefault();

            return kbQueryItem;
        }

        public List<CuratedKBResult> GetDocsByIds(IList<string> docsIds)
        {
            if (_client == null)
            {
                _client = new DocumentClient(new Uri(docDbEndpointUri), docDbPrimaryKey);
            }

            var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);


            List<CuratedKBResult> UnsortedkbQueryItems = _client.CreateDocumentQuery<CuratedKBResult>(collectionLink)
                                          .Where(so => docsIds.Contains(so.DocId) && !so.IsDeleted)
                                          .AsEnumerable()
                                          .ToList();

            var kbQueryItems = UnsortedkbQueryItems.OrderBy(d => docsIds.IndexOf(d.DocId)).ToList();

            return kbQueryItems;
        }

        public CuratedKBResult GetDocByKBId(string kbId)
        {
            if (_client == null)
            {
                _client = new DocumentClient(new Uri(docDbEndpointUri), docDbPrimaryKey);
            }

            var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);

            CuratedKBResult kbQueryItem = _client.CreateDocumentQuery<CuratedKBResult>(collectionLink)
                                            .Where(so => so.KbId == kbId && !so.IsDeleted)
                                            .AsEnumerable()
                                            .FirstOrDefault();

            return kbQueryItem;
        }

        public async Task<bool> SaveDoc(CuratedKBResult kb)
        {
            if (_client == null)
            {
                _client = new DocumentClient(new Uri(docDbEndpointUri), docDbPrimaryKey);
            }
            var ret = await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, kb.DocId), kb);
            return ret.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> UpdateTags(string kbId, string[] tags, int insertIndex = 0)
        {
            if (string.IsNullOrEmpty(kbId))
            {
                return await Task.FromResult(false);
            }

            var kb = GetDocByKBId(kbId);
            kb.Tags = CommonHelper.JoinArray(tags, kb.Tags);
            return await SaveDoc(kb);
        }

        public CuratedKBResult GetByKBId(string kbId)
        {
            if (_client == null)
            {
                _client = new DocumentClient(new Uri(docDbEndpointUri), docDbPrimaryKey);
            }

            var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = 1 };
            var query = string.Format("SELECT * FROM c WHERE c.kbId = '{0}'", kbId);
            var kbQueryItems = _client.CreateDocumentQuery(collectionLink, query, queryOptions);
            return kbQueryItems?.AsEnumerable().FirstOrDefault();
        }

        public CuratedKBResult GetDocByKBClusterName(string kbClusterName)
        {
            if (_client == null)
            {
                _client = new DocumentClient(new Uri(docDbEndpointUri), docDbPrimaryKey);
            }

            var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = 1 };
            var query = string.Format("SELECT c.id, c.kbId, c.isDeleted, c.tags, c.tags_ar, c.clusters, c.answers, c.actions FROM c JOIN f IN c.clusters WHERE LOWER(f.name) = '{0}'",
                kbClusterName.ToLower().Replace("'", "\\'"));
            var kbQueryItems = _client.CreateDocumentQuery(collectionLink, query, queryOptions);
            return kbQueryItems?.AsEnumerable().FirstOrDefault();
        }
    }


}