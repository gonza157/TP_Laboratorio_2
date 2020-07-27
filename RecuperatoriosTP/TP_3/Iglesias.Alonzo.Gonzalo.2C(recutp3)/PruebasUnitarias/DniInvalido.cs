using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exepciones;
using EntidadesAbstractas;
using Clases_Instanciablas;

namespace PruebasUnitarias
{
    [TestClass]
    public class DniInvalido
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestMethod1()
        {
            //arange
            bool valorEsperado = false;
            Alumno a1;
            //act

            a1 = new Alumno(1, "pepe", "mal", "123456f", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            //assert
        }
    }
}
