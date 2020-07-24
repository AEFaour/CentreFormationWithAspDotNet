using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ClassLibraryGeometrie;
using ConsoleAppCalcul;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationGestionParcours.Controllers;
using WebApplicationGestionParcours.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // S'arranger pour effectuer le test 
            // Ajouter une référence au projet à tester
            // Je définis la valeur attendu 
            int result = 9;

            // Act 

            Calcul calcul = new Calcul();
            int k = calcul.Addition(4, 5);
            // Assert (Execution & test)

            //Assert.AreEqual(9, calcul.Addition(4, 5), "4 + 5 ne font plus 9, Supprenant... ");
            Assert.AreEqual(9, k, "4 + 5  est bien 8 ");

            ;


        }
        [TestMethod]
        public void TestMethod2()
        {
            // Exemple 2
            int i = 5 + 5;

            Assert.AreEqual(10, i, " test fail");
        }
        [TestMethod]
        public void Testdll()
        {
            //Arrange -- Ajouter ref
            double L = 9, D = 3, Expected = 24;
            // Act
            Perimetre perimetre = new Perimetre();
            double p = perimetre.PerimetreRectagle(9, 3);
            // Assert

            Assert.AreEqual(Expected, p, "test fail");

        }

        [TestMethod]
        public void TestEditGestionParcours()
        {
            //Arrangement 
            // 1 - Un acces à la base de donnée (ConnectionString)
            // 2 - EntityFrameword à mettre en place
            // 3 - Package MVC
            // 4 - Acces au projet

            //Acte 

            // 1 - instancier le controller à tester
            var _controller = new ParcoursController();

            // On exscuter l'action edit qui retourne une View de type ActionResult
            //TaskActionResult>

            //var _result = (Task<ActionResult>) _controller.Edit(2);
            var _result = _controller.Edit(2) as Task<ActionResult>;

            // Récupérer le viewrESULT

            var _viewResult = _result.Result as ViewResult;

            //utiliser le modle du controlller 

            var _model = _viewResult.Model as ParcoursMVC;

            //Assert
            Assert.AreEqual(2, _model.Id, " Vous n'editez pas le bon parcours");

            // Affectuer un test unitaire pour l'actio, detail du controller module

        }
    }
}

