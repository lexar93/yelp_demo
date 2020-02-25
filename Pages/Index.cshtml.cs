using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnowledgeGraph.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public SelectList Dishes { get; set; }
        public string SelectedDish { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public PageResult OnGet()
        {
            List<SelectListItem> platos = new List<SelectListItem>
            {
                new SelectListItem{ Value = "sushi", Text = "Sushi"},
                new SelectListItem{ Value = "chicken", Text = "Chicken"},
                new SelectListItem{ Value = "soup", Text = "Soup"},
                new SelectListItem{ Value = "salad", Text = "Salad"},
                new SelectListItem{ Value = "shrimp", Text = "Shrimp"}

            };

            Dishes = new SelectList(platos, "Value", "Text");

            return Page();
        }

    }
}
