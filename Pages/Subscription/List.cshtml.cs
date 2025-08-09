using GestionGym.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Pages.Subscription
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public List<Models.Domain.Subscription> Subscriptions { get; set; }

        public async Task OnGetAsync()
        {
            Subscriptions = await _dbContext.Subscriptions
                .Include(s => s.Member) // Charge l'objet associ� avec la cl� �trang�re
                .ToListAsync();
        }

        public ListModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public IActionResult OnPostDelete(int id)
        {
            var subscription = _dbContext.Subscriptions.Find(id);

            if (subscription != null)
            {
                _dbContext.Subscriptions.Remove(subscription);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = "Subscription deleted successfully.";
            }

            return RedirectToPage();
        }


    }
}
