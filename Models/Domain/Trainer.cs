using System.Security.Claims;

namespace GestionGym.Models.Domain
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; } // Ex : Cardio, Musculation
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Class> Classes { get; set; } //un trainer peut avoir plusieurs classes
    }

}
