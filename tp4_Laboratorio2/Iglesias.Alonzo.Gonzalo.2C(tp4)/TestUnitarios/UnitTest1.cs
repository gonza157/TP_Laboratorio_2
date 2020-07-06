using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        //1. Realizar test que verifique que la lista de Paquetes del Correo esté instanciada.
        [TestMethod]
        public void ListaDePaquetesInstanciada()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c);
            Assert.IsNotNull(c.Paquetes);

        }

        //2. Realizar test que verifique que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoExeption))]
        public void ControlDeIDTrakingRepetido()
        {
            Correo correo = new Correo();
            Paquete paq1 = new Paquete("Error", "123-456-1234");
            Paquete paq2 = new Paquete("Error", "123-456-1234");
            correo = correo + paq1;
            correo = correo + paq1;
        }
    }
}
