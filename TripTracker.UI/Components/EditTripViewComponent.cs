using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripTracker.BackService.Models;

namespace TripTracker.UI.ViewComponents
{
    public class EditTripViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Trip trip)
        {
            await Task.Delay(0);
            return View("EditTrip", trip);
        }
    }
}