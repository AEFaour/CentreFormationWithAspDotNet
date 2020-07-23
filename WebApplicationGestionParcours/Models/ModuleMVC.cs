using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationGestionParcours.Controllers;

namespace WebApplicationGestionParcours.Models
{
    public class ModuleMVC : IValidatableObject
    {
        public int Id { get; set; }
        public int idParcours { get; set; }
        [Required(ErrorMessage = "Labelle de module est obligatoire")]
        [StringLength(100, ErrorMessage = "Longue max du labelle 100 caractères")]
        [DataType(DataType.Text)]
        public string Libelle { get; set; }
        public int NoteActuelle { get; set; }
        public DateTime DateDerniereEval { get; set; }
        [Required(ErrorMessage = "Uploader l'image par défaut, si aucune image disponible")]
        [Display(Name = "Image-logo du parcours à uploader")]
        public string Logo { get; set; }
        [Required(ErrorMessage = "La Description de module est requis"),
            MinLength(5), MaxLength(200)]
        [Display(Name = "Description")] // Info-bulle
        [DataType(DataType.Text)]
        public string infos { get; set; }

        public virtual Parcours Parcours { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var ValidationResult = new List<ValidationResult>();
            // Un slogan ne peut pas commencer par la lettre "A"

            if (infos.StartsWith("I") || InfosNonRepeate(infos))
            {
                var erreur = new ValidationResult("Les infos ne peut pas commencer par la lettre 'I'" +
                    " ou ne peut pas êtes anciens",
                    new List<String> { "infos" });

                ValidationResult.Add(erreur);
            }

            return ValidationResult;
        }

        private bool InfosNonRepeate(string infos)
        {
            return (new ModulesController()).AreInfosNotRepeate(infos);
        }
    }
}