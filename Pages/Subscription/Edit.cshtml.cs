using GestionGym.Data;
using GestionGym.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionGym.Pages.Subscription
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty]
        public EditSubscriptionViewModel EditSubscriptionViewModel { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Chargement de l'abonnement existant dans le formulaire
        public IActionResult OnGet(int id)
        {
            var subscription = _dbContext.Subscriptions.Find(id);

            if (subscription == null)
            {
                return NotFound();
            }

            EditSubscriptionViewModel = new EditSubscriptionViewModel
            {
                Id = subscription.Id,
                Name = subscription.Name,
                Price = subscription.Price,
                DurationInDays = subscription.DurationInDays,
                StartDate = subscription.StartDate,
                MemberId = subscription.MemberId // Garder en mémoire mais non éditable
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (EditSubscriptionViewModel != null)
            {
                var existingSubscription = _dbContext.Subscriptions.Find(EditSubscriptionViewModel.Id);

                if (existingSubscription != null)
                {
                    // Seuls ces champs seront modifiés
                    existingSubscription.Name = EditSubscriptionViewModel.Name;
                    existingSubscription.Price = EditSubscriptionViewModel.Price;
                    existingSubscription.DurationInDays = EditSubscriptionViewModel.DurationInDays;
                    existingSubscription.StartDate = EditSubscriptionViewModel.StartDate;

                    _dbContext.SaveChanges();
                }

                TempData["SuccessMessage"] = "Abonnement mis à jour avec succès.";
                return RedirectToPage("/Subscription/List");
            }

            return Page();
        }
    }
}
