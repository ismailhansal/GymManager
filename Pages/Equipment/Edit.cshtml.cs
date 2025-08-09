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








        // Chargement de l'�quipement dans le formulaire d'�dition
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

        // Soumission des donn�es apr�s �dition


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







            TempData["SuccessMessage"] = "�quipement mis � jour avec succ�s.";




            





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









    
