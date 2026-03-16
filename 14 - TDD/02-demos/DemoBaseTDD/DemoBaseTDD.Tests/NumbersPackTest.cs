namespace DemoBaseTDD.Tests;

[TestClass]
public class NumbersPackTest
{
    private NumbersPack _pack;

    private void Setup(int count)
    {
        _pack = new NumbersPack(count);
    }

    // verifier que le resultat est non vide
    [TestMethod]
    public void WhenGetNumbers_Count1_ThenResultIsNotEmpty()
    {
        Setup(1);
        List<int> results = _pack.GetNumbers();
        Assert.AreNotEqual(0, results.Count());
    }

    // verifier que la liste contient une valeur
    [TestMethod]
    public void WhenGetNumbers_Count1_ThenResultCountains0()
    {
        Setup(1);
        List<int> results = _pack.GetNumbers();

        CollectionAssert.Contains(results, 0);

        // contient uniquement 0 => meme taille + meme contenu
        var expected = new List<int> { 0 };
        CollectionAssert.AreEquivalent(expected,results);
       
    }
}
