using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TripTracker.BackService.Models;
using TripTracker.UI.Services;

namespace TripTracker.UI.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient _client;

        public CreateModel(IApiClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _client.AddTripAsync(Trip);

            return RedirectToPage("./Index");
        }
    }
}