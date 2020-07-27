using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciablas;
using Exepciones;

namespace PruebasUnitarias
{
    [TestClass]
    public class AlumnoRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestMethod1()
        {
            //arenge
            Universidad uni;
            Alumno a1;
            Alumno a2;
            //act
            uni = new Universidad();
            a1 = new Alumno(1, "pepe", "mal", "12345656", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            a2 = new Alumno(1, "jorje", "repe", "12345656", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            uni += a1;
            uni += a2;

            //assert
        }
    }
}
