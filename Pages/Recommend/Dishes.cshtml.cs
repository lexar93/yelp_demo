using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnowledgeGraph.Pages.Recommend
{
    public class DishesModel : PageModel
    {

        public SelectList Restaurants { get; set; }
        public string SelectedRestaurant { get; set; }

        public PageResult OnGet()
        {
            List<SelectListItem> restaurants = new List<SelectListItem>
            {
                new SelectListItem{ Value = "MusashiJapaneseRestaurant", Text = "MusashiJapaneseRestaurant"},
                new SelectListItem{ Value = "Manzetti'sTavern", Text = "Manzetti'sTavern"},
                new SelectListItem{ Value = "EmeraldChineseRestaurant", Text = "EmeraldChineseRestaurant"},
                new SelectListItem{ Value = "MadCrushWineBar", Text = "MadCrushWineBar"},
                new SelectListItem{ Value = "PearlGarden", Text = "PearlGarden"}

            };

            Restaurants = new SelectList(restaurants, "Value", "Text");

            return Page();

        }
    }
}