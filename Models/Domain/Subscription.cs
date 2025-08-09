namespace GestionGym.Models.Domain
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; } 
        public int DurationInDays { get; set; } 

        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 

        
        public int MemberId { get; set; } // Clé étrangère vers le membre
        public Member Member { get; set; } //Référence vers l'objet member qui a pris l'abonnement pour acceder rapidement
    }

}
