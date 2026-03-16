using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBaseTDD.TestXUnit
{
    public class CalculTest : IDisposable
    {
        private Calcul? _calcul;

        // Setup
        public CalculTest() { 
            _calcul = new Calcul();
        }

        public void Dispose()
        {
            _calcul = null;
        }

        [Fact]
        public void WhenAddition_5_6_Then_11()
        {
            // Arrange
            var calcul = new Calcul();

            // Act
            var result = calcul.Addition(5, 6);

            // Assert
            Assert.Equal(11, result);

            
        }
    }
}
