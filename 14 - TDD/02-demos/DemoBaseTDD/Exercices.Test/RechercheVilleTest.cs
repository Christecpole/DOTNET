namespace Exercices.Test;

[TestClass]
public class RechercheVilleTest
{

    private RechercheVille _rechercheVille = new RechercheVille(new List<string>() {
            "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne" });


    // 1. Si le texte de la recherche contient moins de 2 caractères, ***Une exception est levée de type NotFoundException***.
    [TestMethod]
    public void RechercherTestWhenLess_2_Char_Raise_NotFoundException()
    {
        Assert.ThrowsExactly<NotFoundException>(() => _rechercheVille.Rechercher("a"));
    }

    // 2. Si le texte de recherche est égal ou supérieur à 2 caractères, il doit renvoyer tous les noms de ville commençant par le texte de recherche exact.
    [TestMethod]
    public void RechercherTestWhenGt_2_Char_Return_Cities_Started_With_Char()
    {
        List<string> result = _rechercheVille.Rechercher("Va");

        CollectionAssert.AreEqual(new List<string>() { "Valence", "Vancouver" }, result);
    }

    // 3. La fonctionnalité de recherche doit être insensible à la casse
    [TestMethod]
    public void RechercherTestWhenGt_No_Case_Sensitive()
    {
        List<string> result = _rechercheVille.Rechercher("vA");

        CollectionAssert.AreEqual(new List<string>() { "Valence", "Vancouver" }, result);
    }

    // 4. La fonctionnalité de recherche devrait également fonctionner lorsque le texte de recherche n'est qu'une partie d'un nom de ville
    [TestMethod]
    public void RechercherTestWhenGt_2_Char_Return_Cities_Contains_With_Char()
    {
        List<string> result = _rechercheVille.Rechercher("ape");

        CollectionAssert.AreEqual(new List<string>() { "Budapest" }, result);
    }

    // 5. Si le texte de recherche est un « * » (astérisque), il doit renvoyer tous les noms de ville.
    [TestMethod]
    public void RechercherTestWhen_Char_Asterisk_Return_All_Cities()
    {
        List<string> result = _rechercheVille.Rechercher("*");

        CollectionAssert.AreEqual(new List<string>() {
            "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne" },result);
    }
}
