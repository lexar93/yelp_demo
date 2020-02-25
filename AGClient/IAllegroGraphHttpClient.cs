using Newtonsoft.Json.Linq;

namespace KnowledgeGraph.AGClient
{
    public interface IAllegroGraphHttpClient
    {

        public string EvalSPARQLQuery(string query);
    }
}
