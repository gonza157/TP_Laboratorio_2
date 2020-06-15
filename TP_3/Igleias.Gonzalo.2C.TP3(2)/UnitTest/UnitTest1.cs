using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arange

            Jornada j;
            bool valorEsperado = true;
            bool flag = false;
            Profesor p1;
            //act
            j = new Jornada(Universidad.EClases.Laboratorio,p1 = new Profesor(1,"pepe","santo","12345678",Persona.ENacionalidad.Argentino));
           
            if (j.Alumnos != null)
            {
                flag = true;
            }

            //assert
            Assert.AreEqual(valorEsperado, flag);
        }
    }
}
