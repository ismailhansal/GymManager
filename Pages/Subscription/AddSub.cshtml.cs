using GestionGym.Data;
using GestionGym.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionGym.Pages.Subscription
{
    public class AddSubModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public AddSubModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public AddSubscriptionViewModel AddSubscriptionRequest { get; set; }

        public void OnGet(int? memberId)
        {
            if (memberId == null)
            {
                TempData["ErrorMessage"] = "Vous devez sélectionner un membre.";
                return;
            }

            // Pré-remplissage avec l'ID du membre dans le formulaire
            AddSubscriptionRequest = new AddSubscriptionViewModel
            {
                MemberId = memberId.Value
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Formulaire invalide.";
                return Page();
            }

            var subscriptionDomainModel = new GestionGym.Models.Domain.Subscription
            {
                MemberId = AddSubscriptionRequest.MemberId,
                Name = AddSubscriptionRequest.Name,
                Price = AddSubscriptionRequest.Price,
                DurationInDays = AddSubscriptionRequest.DurationInDays,
                StartDate = AddSubscriptionRequest.StartDate
            };

            _dbContext.Subscriptions.Add(subscriptionDomainModel);
            _dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Abonnement ajouté avec succès.";
            return RedirectToPage("/Subscription/Add");
        }
    }
}
