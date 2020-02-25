using KnowledgeGraph.AGClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace KnowledgeGraph.Pages.Food
{
    public class SentimentAnalysisModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SelectedDish { get; set; }

        public JObject jsonResponse;

        private readonly IAllegroGraphHttpClient _httpClient;
        public SentimentAnalysisModel(IAllegroGraphHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void OnGet()
        {
            string query = "PREFIX : <http://www.myorg/yelp_restaurants2#> PREFIX type: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>  SELECT DISTINCT ?Review ?Restaurant ?o WHERE { ?Restaurant :hasReview ?Review. ?Review :Sentiment ?o. filter ( ?o > 0.9 ). }";
            
            string response = _httpClient.EvalSPARQLQuery(query);
            jsonResponse = JObject.Parse(response);
        }
    }
}