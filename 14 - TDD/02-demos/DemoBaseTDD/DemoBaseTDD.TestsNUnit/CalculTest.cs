namespace DemoBaseTDD.TestsNUnit;

public class CalculTest
{
    [SetUp] // s'executera AVANT chaque test
    public void Setup()
    {
    }

    [TearDown]  // s'exectura Apres chaque test
    public void Teardown() { 
     
    }

    [OneTimeSetUp] // s'exectura UNE FOIS AVANT tous les test
    public void OneTimeSetUp() {
        
     }

    [OneTimeTearDown] // s'exectura UNE FOIS APRES tous les test
    public void OneTimeTearDown() { 
    }

    [Test]
    public void WhenAddition_10_30_Then_40()
    {
       // Assert.Pass(); // fais passer le test
       // Arrange 
       var calcul = new Calcul();

        // Act 
        var result = calcul.Addition(10, 30);

        // Assert
        Assert.That(result, Is.EqualTo(40));

    }
}
