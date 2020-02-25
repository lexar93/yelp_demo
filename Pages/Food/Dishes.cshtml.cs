using KnowledgeGraph.AGClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace KnowledgeGraph.Pages.Food
{
    public class DishesModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string SelectedRestaurant { get; set; }

        public JObject jsonResponse;

        private readonly IAllegroGraphHttpClient _httpClient;


        public DishesModel(IAllegroGraphHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void OnGet()
        {
            //string query = "PREFIX ex: <http://www.myorg/yelp_restaurants2#> PREFIX type: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> SELECT DISTINCT ?Restaurant where { ?Restaurant ex:hasDish ?Dish; FILTER(contains(str(?Dish), \"" + SelectedRestaurant + "\"))}";
            string query = "PREFIX ex: <http://www.myorg/yelp_restaurants2#> PREFIX type: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> SELECT DISTINCT ?Dish where { ?Restaurant ex:hasDish ?Dish; FILTER(contains(str(?Restaurant), \"" + SelectedRestaurant + "\"))}";
          
            string response = _httpClient.EvalSPARQLQuery(query);
            jsonResponse = JObject.Parse(response);
        }
    }
}