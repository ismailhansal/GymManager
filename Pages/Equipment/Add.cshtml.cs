// Importation des namespaces nécessaires pour le fonctionnement du code
using GestionGym.Data; // Namespace pour interagir avec la base de données via ApplicationDbContext
using GestionGym.Models.ViewModels; // Namespace contenant les modèles de vue (ViewModels)
using Microsoft.AspNetCore.Mvc; // Fournit des fonctionnalités ASP.NET Core MVC (ex : [BindProperty], IActionResult)
using Microsoft.AspNetCore.Mvc.RazorPages; // Fournit la classe PageModel et les fonctionnalités Razor Pages

// Déclaration du namespace pour organiser le code et regrouper les fonctionnalités liées à la gestion des équipements
namespace GestionGym.Pages.Equipment
{
    // Déclaration de la classe principale qui gère la page Razor
    public class AddModel : PageModel
    {
        // Propriété privée et en lecture seule pour interagir avec la base de données
        private readonly ApplicationDbContext _dbContext;

        // Constructeur de la classe AddModel qui injecte ApplicationDbContext
        public AddModel(ApplicationDbContext dbContext)
        {
            // Assignation de l'instance injectée à la propriété privée
            _dbContext = dbContext;
        }

        // Propriété liée au formulaire de la page (binding automatique des données envoyées par POST/GET)
        [BindProperty] // Permet de lier les données du formulaire à cette propriété
        public AddEquipmentViewModel AddEquipmentRequest { get; set; }

        // Méthode appelée lors d'une requête GET (lorsqu'on accède à la page pour la première fois)
        public void OnGet()
        {
            // Aucune action spécifique pour le moment
        }

        // Méthode appelée lors d'une requête POST (soumission du formulaire)
        public IActionResult OnPost()
        {
            // Création d'un nouvel objet du domaine "Equipment" avec les données du formulaire
            var equipmentDomainModel = new GestionGym.Models.Domain.Equipment
            {
                Name = AddEquipmentRequest.Name, // Assignation du nom
                Description = AddEquipmentRequest.Description, // Assignation de la description
                Quantity = AddEquipmentRequest.Quantity, // Assignation de la quantité
                MaintenanceDate = AddEquipmentRequest.MaintenanceDate // Assignation de la date de maintenance
            };

            // Ajout du nouvel équipement à la collection d'équipements dans la base de données
            _dbContext.Equipments.Add(equipmentDomainModel);
            // Sauvegarde des modifications dans la base de données
            _dbContext.SaveChanges();

            // Redirection vers une autre page (liste des équipements)
            return Redirect("/Equipment/List");
        }
    }
}
