namespace GestionGym.Models.ViewModels
{
    public class EditSubscriptionViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }

        public DateTime StartDate { get; set; }


        public int MemberId { get; set; } // Clé étrangère vers le membre
    }
}
