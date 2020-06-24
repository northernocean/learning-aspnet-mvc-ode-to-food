﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {

            Restaurant = restaurantData.GetById(restaurantId);
            if(Restaurant is null)
                return RedirectToPage("/Error");
            else
            {
                return Page();
            }

        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);
            
            if(restaurant is null)
                return RedirectToPage("/Error");
            else
            {
                restaurantData.Commit();
                TempData["Message"] = $"{restaurant.Name} deleted.";
                return RedirectToPage("./List");
            }
        }
    
    }
}