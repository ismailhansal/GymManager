using GestionGym.Data;
using GestionGym.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionGym.Pages.Member
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;




        public AddModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [BindProperty]

        public AddMemberViewModel AddMemberRequest { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var memberDomainModel = new GestionGym.Models.Domain.Member
            {
                FirstName = AddMemberRequest.FirstName,
                LastName = AddMemberRequest.LastName,
                Email = AddMemberRequest.Email,
                Address = AddMemberRequest.Address,
                DateOfBirth = AddMemberRequest.DateOfBirth,
                PhoneNumber = AddMemberRequest.PhoneNumber
            };

            _dbContext.Members.Add(memberDomainModel);
            _dbContext.SaveChanges();

            // Redirige vers /Member/List
            return Redirect("/Member/List");
        }

    }







}