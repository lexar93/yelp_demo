using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Model;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Query;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.RepositoryUtil;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Sail;
using KnowledgeGraph.AGClient;
using Newtonsoft.Json;
using KnowledgeGraph.Models;

namespace KnowledgeGraph.Pages.Food
{
    public class RestaurantModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SelectedDish { get; set; }

        public string resultQuery;

        public JObject jsonResponse;

        private readonly IAllegroGraphHttpClient _httpClient;

        public RestaurantModel(IAllegroGraphHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void OnGet()
        {

            string query = "PREFIX ex: <http://www.myorg/yelp_restaurants2#> PREFIX type: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> SELECT DISTINCT ?Restaurant where { ?Restaurant ex:hasDish ?Dish; FILTER(contains(str(?Dish), \"" + SelectedDish + "\"))}";
            string query2 = "select distinct ?class {?resource a ?class}";

            string response = _httpClient.EvalSPARQLQuery(query);
            jsonResponse = JObject.Parse(response);
       
        }
    }
}