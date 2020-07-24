using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationGestionParcours.Controllers;
using WebApplicationGestionParcours.Models;

namespace UnitTestProjectGestionParcours
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrangement 
            // 1 - Un acces à la base de donnée (ConnectionString)
            // 2 - EntityFrameword à mettre en place
            // 3 - Package MVC
            // 4 - Acces au projet

            //Acte 

            //  instancier le controller à tester
            int tested = 3;
            var _controller = new ModulesController();

            var _result = _controller.Details(3);

            var _viewResult = _result.Result as ViewResult;

            var _model1 = _viewResult.Model as Module;

            Assert.AreEqual(tested, _model1.Id, " Votre module n'existe pas");
        }
    }
}
