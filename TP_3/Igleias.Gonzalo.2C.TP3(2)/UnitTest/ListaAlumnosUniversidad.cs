using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;

namespace UnitTest
{
    [TestClass]
    public class ListaAlumnosUniversidad
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arange

            Universidad uni;
            bool valorEsperado = true;
            bool flag = false;
            //act
            uni = new Universidad();
            if(uni.Alumnos != null)
            {
                flag = true;
            }

            //assert
            Assert.AreEqual(valorEsperado,flag);
        }
    }
}
