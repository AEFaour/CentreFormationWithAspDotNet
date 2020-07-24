namespace WebApplicationTestAuth.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFAbonnesDBContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « EFAbonnesDBContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « WebApplicationTestAuth.Models.EFAbonnesDBContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « EFAbonnesDBContext » dans le fichier de configuration de l'application.
        public EFAbonnesDBContext()
            : base("name=ConnectionBaseAbonne")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Abonne> Abonnes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}