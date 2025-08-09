using GestionGym.Data;
using GestionGym.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionGym.Pages.Member
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Models.Domain.Member Member { get; set; }

        [BindProperty]
        public EditMemberViewModel EditMemberViewModel { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // Chargement du membre dans le formulaire d'édition
        public void OnGet(int id)
        {
            var member = _dbContext.Members.Find(id);

            EditMemberViewModel = new EditMemberViewModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber,
                DateOfBirth = member.DateOfBirth,
                Address = member.Address
            };
        }

        // Soumission des données après édition
        public void OnPost()
        {
            if (EditMemberViewModel != null)
            {
                var existingMember = _dbContext.Members.Find(EditMemberViewModel.Id);

                if (existingMember != null)
                {
                    existingMember.FirstName = EditMemberViewModel.FirstName;
                    existingMember.LastName = EditMemberViewModel.LastName;
                    existingMember.Email = EditMemberViewModel.Email;
                    existingMember.PhoneNumber = EditMemberViewModel.PhoneNumber;
                    existingMember.DateOfBirth = EditMemberViewModel.DateOfBirth;
                    existingMember.Address = EditMemberViewModel.Address;

                    _dbContext.SaveChanges();
                }
            }

            TempData["SuccessMessage"] = "Membre mis à jour avec succès.";
        }
    }
}
