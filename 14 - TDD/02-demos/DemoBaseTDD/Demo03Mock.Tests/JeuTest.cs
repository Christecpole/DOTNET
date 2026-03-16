using Demo03Mock.Core;
using Moq;

namespace Demo03Mock.Tests;

[TestClass]
public class JeuTest
{
    [TestMethod]
    public void Jouer_Win()
    {
        // Arrange
        IDe dewin = Mock.Of<IDe>(); // creation du "faux" de
        Mock.Get(dewin).Setup(d => d.Lancer()).Returns(20); // reglage de la methode lancer du "faux" de

        Jeu jeu = new Jeu(dewin);

        // Act
        bool result = jeu.Jouer();

        // Assert
        Assert.IsTrue(result);

    }


    [TestMethod]
    public void Jouer_Loose()
    {
        // Arrange
        IDe dewin = Mock.Of<IDe>(); // creation du "faux" de
        Mock.Get(dewin).Setup(d => d.Lancer()).Returns(15); // reglage de la methode lancer du "faux" de

        Jeu jeu = new Jeu(dewin);

        // Act
        bool result = jeu.Jouer();

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void JouerAvecBonus_ItIsAny_Demo()
    {
        // Arrange
        IDe dewin = Mock.Of<IDe>(); // creation du "faux" de

        Mock.Get(dewin)
            .Setup(d => d.LancerAvecBonus(It.IsAny<int>()))
            .Returns(20); // reglage de la methode lancer du "faux" de

        Jeu jeu = new Jeu(dewin);

        // Act
        bool result1 = jeu.JouerAvecBonus(10);
        bool result2 = jeu.JouerAvecBonus(999);
        bool result3 = jeu.JouerAvecBonus(45);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
    }

    [TestMethod]
    public void Jouer_Verify_Demo()
    {
        // Arrange
        IDe dewin = Mock.Of<IDe>(); // creation du "faux" de

        Mock.Get(dewin)
            .Setup(d => d.Lancer())
            .Returns(20);

        Jeu jeu = new Jeu(dewin);

        // Act 
        jeu.Jouer();

        // Assert
        // Verifie que Lancer() a bien ete appele
        Mock.Get(dewin).Verify(d => d.Lancer());
        // verification du nombre d'appel de la methode Lancer()
        //Mock.Get(dewin).Verify(d => d.Lancer(),Times.Once); // 1 fois
        //Mock.Get(dewin).Verify(d => d.Lancer(),Times.Never); // jamais
        //Mock.Get(dewin).Verify(d => d.Lancer(),Times.Exactly(3)); // exactement 3fois
        //Mock.Get(dewin).Verify(d => d.Lancer(),Times.AtLeastOnce()); // au moins une fois


    }
}
