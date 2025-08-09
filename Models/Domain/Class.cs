namespace GestionGym.Models.Domain
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } // Ex : Yoga, Zumba
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TrainerId { get; set; } // Relation avec l'entraîneur
        public Trainer Trainer { get; set; }
        public ICollection<Member> Attendees { get; set; } // les membres peuvent etre inscrits à plusieurs cours
    }

}
