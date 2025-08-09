namespace GestionGym.Models.ViewModels
{
    public class EditEquipmentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime MaintenanceDate { get; set; }
    }
}
