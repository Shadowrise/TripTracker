﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TripTracker.BackService.Models;
using TripTracker.UI.Services;

namespace TripTracker.UI.Pages.Trips
{
    public class DeleteModel : PageModel
    {
        private readonly IApiClient _client;

        public DeleteModel(IApiClient client)
        {
            _client = client;
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _client.GetTripAsync(id.Value);

            if (Trip == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _client.GetTripAsync(id.Value);

            if (Trip != null)
            {
                await _client.RemoveTripAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
