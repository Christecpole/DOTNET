namespace DemoBaseTDD.Tests;

[TestClass]
public class CalculTest
{
    private Calcul? _calcul;

    //[ClassInitialize] // s'executera UNE fois avant tous les test
    //public void OneTimeSetUp( )
    //{
    //    _calcul = new Calcul();
    //}

    //[ClassCleanup] // s'executera UNE fois apres tous les test
    //public void OneTimeTearDown()
    //{
    //    _calcul = null;
    //}

    [TestInitialize] // s'executera Avant chaque test
    public void SetUp()
    {
        _calcul = new Calcul();
    }

    [TestCleanup] // s'executera Apres chaque test
    public void TearDown()
    {
        _calcul = null;
    }

    [TestMethod]
    public void WhenAddition_42_7_Then_49()
    {
        // Arrange
        var calcul = new Calcul();

        // Act
        var result = calcul.Addition(42, 7);

        // Assert
        Assert.AreEqual(49, result);
    }

    [TestMethod]
    public void WhenDivision_30_10_Then_3()
    {
        // Arrange
        var calcul = new Calcul();

        // Act
        var result = calcul.Division(30, 10);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void WhenDivision_1_0_Then_DivideByZeroException()
    {
        // Arrange
        var calcul = new Calcul();

        // Act et Assert
        // Assert.ThrowsExceptions<DivideByZeroException>(() => calcul.Division(1, 0));
        //Assert.Throws<DivideByZeroException>(() => calcul.Division(1, 0));
        Assert.ThrowsExactly<DivideByZeroException>(() => calcul.Division(1, 0));

        //try
        //{
        //    calcul.Division(1, 0);
        //}
        //catch (Exception ex)
        //{
        //    Assert.AreEqual(typeof(DivideByZeroException), ex.GetType());
        //}

       
    }
}
