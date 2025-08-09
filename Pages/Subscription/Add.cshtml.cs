using GestionGym.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GestionGym.Pages.Subscription
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public List<Models.Domain.Member> Members { get; set; }


        public AddModel(ApplicationDbContext dbContext)
        { 
            this._dbContext = dbContext;


        }
        public void OnGet()
        {
            Members = _dbContext.Members.ToList();
        }



        



    }
}
