namespace GestionGym.Models.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        // Relation avec les abonnements
        public ICollection<Subscription> Subscriptions { get; set; } //Un membre peut avoir plusieurs abonnements
    }

}
