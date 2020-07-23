using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationGestionParcours.Controllers;

namespace WebApplicationGestionParcours.Models
{
    public class ParcoursMVC : IValidatableObject
    //IValidatatableObject pour des validations complexe côté server
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nom du Parcours est obligatoire")]
        [StringLength(100, ErrorMessage = "Longue max du titre 100 caractères")]
        [DataType(DataType.Text)]

        public string Nom { get; set; }
        [Required(ErrorMessage = "L'Objectif du Parcours est requis"),
            MinLength(5), MaxLength(100)]
        [Display(Name = "Objectif")] // Info-bulle
        [DataType(DataType.Text)]

        public string Slogan { get; set; }
        [Required(ErrorMessage = "Uploader l'image par défaut, si aucune image disponible")]
        [Display(Name = "Image-logo du parcours à uploader")]
        public string Logo { get; set; }

        public virtual ICollection<Module> Module { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var ValidationResult = new List<ValidationResult>();
            // Un slogan ne peut pas commencer par la lettre "A"

            if (Slogan.StartsWith("A") || SloganUnique(Slogan))
            {
                var erreur = new ValidationResult("Le slogan ne peut pas commencer par la lettre 'A'" +
                    " ou ne peut pas faire partie d'un autre slogan déjà utilisé",
                    new List<String> { "Slogan" });

                ValidationResult.Add(erreur);
            }

            return ValidationResult;
        }
        private bool SloganUnique(string slogan)
        {
            return (new ParcoursController()).IsSloganUnique(slogan);
        }
    }
}