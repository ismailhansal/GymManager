using GestionGym.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionGym.Pages.Member
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public List<Models.Domain.Member> Members { get; set; }


        public ListModel(ApplicationDbContext dbContext)
        { this._dbContext = dbContext; }
        public void OnGet()
        {
            Members = _dbContext.Members.ToList();
        }


        public IActionResult OnPostDelete(int id)
        {
            var member = _dbContext.Members.Find(id);

            if (member != null)
            {
                // Supprimer les abonnements associés
                var abonnements = _dbContext.Subscriptions.Where(a => a.Id == id).ToList();
                _dbContext.Subscriptions.RemoveRange(abonnements);

                // Supprimer le membre
                _dbContext.Members.Remove(member);
                _dbContext.SaveChanges();
            }

            TempData["SuccessMessage"] = "Membre et ses abonnements supprimés avec succès.";
            return RedirectToPage("/Member/List");
        }
    }
}
