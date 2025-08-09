// Importation des namespaces n�cessaires pour le fonctionnement du code
using GestionGym.Data; // Namespace pour interagir avec la base de donn�es via ApplicationDbContext
using GestionGym.Models.ViewModels; // Namespace contenant les mod�les de vue (ViewModels)
using Microsoft.AspNetCore.Mvc; // Fournit des fonctionnalit�s ASP.NET Core MVC (ex : [BindProperty], IActionResult)
using Microsoft.AspNetCore.Mvc.RazorPages; // Fournit la classe PageModel et les fonctionnalit�s Razor Pages

// D�claration du namespace pour organiser le code et regrouper les fonctionnalit�s li�es � la gestion des �quipements
namespace GestionGym.Pages.Equipment
{
    // D�claration de la classe principale qui g�re la page Razor
    public class AddModel : PageModel
    {
        // Propri�t� priv�e et en lecture seule pour interagir avec la base de donn�es
        private readonly ApplicationDbContext _dbContext;

        // Constructeur de la classe AddModel qui injecte ApplicationDbContext
        public AddModel(ApplicationDbContext dbContext)
        {
            // Assignation de l'instance inject�e � la propri�t� priv�e
            _dbContext = dbContext;
        }

        // Propri�t� li�e au formulaire de la page (binding automatique des donn�es envoy�es par POST/GET)
        [BindProperty] // Permet de lier les donn�es du formulaire � cette propri�t�
        public AddEquipmentViewModel AddEquipmentRequest { get; set; }

        // M�thode appel�e lors d'une requ�te GET (lorsqu'on acc�de � la page pour la premi�re fois)
        public void OnGet()
        {
            // Aucune action sp�cifique pour le moment
        }

        // M�thode appel�e lors d'une requ�te POST (soumission du formulaire)
        public IActionResult OnPost()
        {
            // Cr�ation d'un nouvel objet du domaine "Equipment" avec les donn�es du formulaire
            var equipmentDomainModel = new GestionGym.Models.Domain.Equipment
            {
                Name = AddEquipmentRequest.Name, // Assignation du nom
                Description = AddEquipmentRequest.Description, // Assignation de la description
                Quantity = AddEquipmentRequest.Quantity, // Assignation de la quantit�
                MaintenanceDate = AddEquipmentRequest.MaintenanceDate // Assignation de la date de maintenance
            };

            // Ajout du nouvel �quipement � la collection d'�quipements dans la base de donn�es
            _dbContext.Equipments.Add(equipmentDomainModel);
            // Sauvegarde des modifications dans la base de donn�es
            _dbContext.SaveChanges();

            // Redirection vers une autre page (liste des �quipements)
            return Redirect("/Equipment/List");
        }
    }
}
