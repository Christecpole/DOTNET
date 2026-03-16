namespace Exercices.Test;

[TestClass]
public class FibTest
{

    private Fib _fib;

    private void Setup(int r)
    {
        _fib = new Fib(r); 
    }


    // Lors du declanchement de la fonction getfibseries avec range 1 resultat non vide
    [TestMethod]
    public void WhenGetFibSeries_Range1_ThenResultIsNotEmpty()
    {
        // Arrange
        Setup(1);

        // Act
        List<int> results = _fib.GetFibSeries();

        // Assert
      //  Assert.IsNotNull(results);
      //  Assert.IsNotEmpty(results);
        Assert.AreNotEqual(0, results.Count);


    }

    //    Le résultat correspond à une liste qui contient {0}
    [TestMethod]
    public void WhenGetFibSeries_IfRange1_ThenResultContains0()
    {
        Setup(1);
        List<int> results = _fib.GetFibSeries();

        CollectionAssert.Contains(results, 0);

        // autre version si le cas de test était "est une liste qui ne contient que 0"
        var list0 = new List<int>() { 0 };
        CollectionAssert.AreEquivalent(list0, results);
    }

    //Lors du déclanchement de la fonction GetFibSeries() avec un Range de 6
    //    Le résultat contient le chiffre 3
    [TestMethod]
    public void WhenGetFibSeries_IfRange6_ThenResultContains3()
    {
        Setup(6);
        List<int> results = _fib.GetFibSeries();

        CollectionAssert.Contains(results, 3);
    }

    //    Le résultat contient 6 éléments
    [TestMethod]
    public void WhenGetFibSeries_IfRange6_ThenResultContains6Elements()
    {
        Setup(6);
        List<int> results = _fib.GetFibSeries();

        Assert.HasCount(6, results);
    }

    //    Le résultat n’a pas le chiffre 4 en son sein
    [TestMethod]
    public void WhenGetFibSeries_IfRange6_ThenResultDoesNotContain4()
    {
        Setup(6);
        List<int> results = _fib.GetFibSeries();

        CollectionAssert.DoesNotContain(results, 4);
    }

    //    Le résultat correspond à une liste qui contient {0, 1, 1, 2, 3, 5}
    [TestMethod]
    public void WhenGetFibSeries_IfRange6_ThenResultContains_0_1_1_2_3_5()
    {
        Setup(6);
        List<int> expected = new List<int>() { 0, 1,1, 2, 3, 5 };

        List<int> results = _fib.GetFibSeries();

        // vérification d'égalité avec une autre liste (même ordre et taille)
        // /!\ pas exactement ce qui est demandé
        //CollectionAssert.AreEqual(expected, results); // passe par la méthode object.Equals(object)
        CollectionAssert.AreEquivalent(expected, results); // vérifie les éléments mais pas l'ordre

        // on cherche à vérifier si la liste contient les éléments
        CollectionAssert.IsSubsetOf(expected, results);
    }

    //    Le résultat est trié de façon ascendance
    [TestMethod]
    public void WhenGetFibSeries_IfRange6_ThenResultIsSortedAscending()
    {
        Setup(6);

        List<int> results = _fib.GetFibSeries();


        List<int> expected = new List<int>(results); // on passe par le constructeur de recopie => /!\ expected = results; copie la référence !
        expected.Sort();

        CollectionAssert.AreEquivalent(expected, results);
    }
}
