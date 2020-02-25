using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Query;
using Newtonsoft.Json.Linq;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.RepositoryUtil;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Sail;

namespace KnowledgeGraph.AGClient
{
    public class AllegroGraphHttpClient : IAllegroGraphHttpClient
    {

        private readonly AllegroGraphServer server;
        private readonly RepositoryConnection repoConn;

        public AllegroGraphHttpClient(string host, int port, string username, string password, string catalog, string repository) {

            server = new AllegroGraphServer(host, port, username, password);

            Catalog cata = server.OpenCatalog(catalog);
            Repository repo = cata.GetRepository(repository);
            repoConn = repo.GetConnection();

        }

        public string EvalSPARQLQuery(string query) {

            string resultQuery = repoConn.EvalSPARQLQuery(queryLanguage: QueryLanguage.SPARQL, queryString: query).ToString();
            resultQuery = resultQuery.Replace("<http://www.myorg/yelp_restaurants#", "");
            resultQuery = resultQuery.Replace("<http://www.myorg/yelp_restaurants2#", "");
            resultQuery = resultQuery.Replace("<http://www.w3.org/2001/XMLSchema#", "");
            resultQuery = resultQuery.Replace(">", "");
            resultQuery = resultQuery.Replace("^^decimal", "");

            return resultQuery;
        }
    }


}
