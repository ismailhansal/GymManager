using GestionGym.Data;
using GestionGym.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;




namespace GestionGym.Pages.Equipment
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Models.Domain.Equipment Equipment { get; set; }
        [BindProperty]
        public EditEquipmentViewModel EditEquipmentViewModel { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        { this._dbContext = dbContext; }








        // Chargement de l'équipement dans le formulaire d'édition
        public void OnGet(int id)
        {
            var equipment = _dbContext.Equipments.Find(id);


            EditEquipmentViewModel = new EditEquipmentViewModel
            {
                Id = equipment.Id,
                Name = equipment.Name,
                Description = equipment.Description,
                Quantity = equipment.Quantity,
                MaintenanceDate = equipment.MaintenanceDate
            };

        }

        // Soumission des données après édition


        public void OnPostUpdate()
        {

            if (EditEquipmentViewModel != null)
            {
                var existingEquipment = _dbContext.Equipments.Find(EditEquipmentViewModel.Id);

                if (existingEquipment != null)
                {
                    existingEquipment.Name = EditEquipmentViewModel.Name;
                    existingEquipment.Description = EditEquipmentViewModel.Description;
                    existingEquipment.Quantity = EditEquipmentViewModel.Quantity;
                    existingEquipment.MaintenanceDate = EditEquipmentViewModel.MaintenanceDate;

                    _dbContext.SaveChanges();


                }
            }







            TempData["SuccessMessage"] = "Équipement mis à jour avec succès.";




            





        }


        public IActionResult OnPostDelete()
        {

            var existingEquipment = _dbContext.Equipments.Find(EditEquipmentViewModel.Id);

            if (existingEquipment != null)
            {
                _dbContext.Equipments.Remove(existingEquipment);
                _dbContext.SaveChanges();

                return RedirectToAction("/Equipment/List");
            }
            return Page();






        }

    }
}









    
