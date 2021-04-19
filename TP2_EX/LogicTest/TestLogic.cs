using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logica;

namespace LogicTest
{
    [TestClass]
    public class TestLogic
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ThrowExceptionTest()
        {
            //Arrange
            Logic exception = new Logic();
            //Act
            exception.ThrowException();
            //Assert es manejado por ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(NoEsParException))]
        public void ThrowNoEsParExceptionTest()
        {
            //Arrange
            Logic exception = new Logic();
            string customMsg = "Mensaje personalizado";
            int numero = 3;
            //Act
            exception.ThrowNoEsParException(customMsg, numero);
            //Assert es manejado por ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionPorCeroTest()
        {
            //Arrange
            DivisionMethod dm = new DivisionMethod();
            int numero = 5;
            //Act
            dm.DivisionPorCero(numero);
            //Assert es manejado por ExpectedException
        }
        [TestMethod]
        public void DivisionEnteraTest()
        {
            //Arrange
            DivisionMethod dm = new DivisionMethod();
            int dividendo = 10;
            int divisor = 2;
            int resultado = 5;
            //Act
            int actual = dm.DivisionEntera(dividendo, divisor);
            //Assert
            Assert.AreEqual(actual, resultado);
        }
    }
}
