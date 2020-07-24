using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationTestAuth.Models
{
    public class Abonne
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "le prénom de l'abonné est obligatoire")]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "l'adresse mail de l'abonné est obligatoire")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
        [Required(ErrorMessage = "l'émail de l'abonné est obligatoire")]
        [Display(Name = "Adresse mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}