using GestionGym.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionGym.Pages.Equipment
{
    public class ListModel : PageModel
    {

        private readonly ApplicationDbContext _dbContext;

        public List<Models.Domain.Equipment > Equipments{ get; set; }


        public ListModel(ApplicationDbContext dbContext)
        { this._dbContext = dbContext; }

        public void OnGet()
        {
            Equipments = _dbContext.Equipments.ToList();
        }


        public IActionResult OnPostDelete(int id)
        {
            var equipment = _dbContext.Equipments.Find(id);

            if (equipment != null)
            {
                _dbContext.Equipments.Remove(equipment);
                _dbContext.SaveChanges();
            }

            TempData["SuccessMessage"] = "Équipement supprimé avec succès.";
            return RedirectToPage("/Equipment/List");
        }
    }
}
