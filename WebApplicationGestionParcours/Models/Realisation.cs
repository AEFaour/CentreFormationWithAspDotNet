//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationGestionParcours.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Realisation
    {
        public int Id { get; set; }
        public Nullable<int> IdModule { get; set; }
        public Nullable<System.DateTime> DateDebut { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
        public string Info { get; set; }
    
        public virtual Module Module { get; set; }
    }
}
