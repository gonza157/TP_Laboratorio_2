﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;

namespace UnitTest
{
    [TestClass]
    public class NacionalidadInvalida
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethod1()
        {
            //arange
            Alumno a1;

            //act

            a1 = new Alumno(1, "pepe", "mal", "12345656", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

            //assert
        }
    }
}
