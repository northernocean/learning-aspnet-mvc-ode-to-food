using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
                if (Restaurant is null)
                    RedirectToPage("/Error");
            }
            else
            {
                Restaurant = new Restaurant();
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (!ModelState.IsValid)
                return Page();

            if (Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
                TempData["Message"] = "Restaurant Updated";
            }
            else
            {
                Restaurant = restaurantData.Add(Restaurant);
                TempData["Message"] = "Restaurant Added";
            }
            restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}