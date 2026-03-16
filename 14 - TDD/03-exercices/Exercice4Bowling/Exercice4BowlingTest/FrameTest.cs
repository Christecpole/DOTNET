using Exercice4Bowling;
using Moq;

namespace Exercice4BowlingTest;

[TestClass]
public class FrameTest
{
    private Frame frame;

    // On crée un "mock" (objet simulé) de IGenerateur.
    // Objectif : supprimer l'aléatoire dans les tests.
    private IGenerateur generateur = Mock.Of<IGenerateur>();

    [TestMethod]
    public void Roll_SimpleFrame_FirstRoll_CheckScore()
    {
        // SUJET : "En série standard, le premier lancer doit augmenter le score"
        //
        // Arrange : on force le générateur à retourner 4 quand on lui demande
        // un nombre de quilles tombées sur un lancer à 10 quilles possibles.
        Mock.Get(generateur).Setup(x => x.RandomPin(10)).Returns(4);

        // Frame normale (lastFrame = false)
        frame = new Frame(generateur, false);

        // Act : on effectue un lancer
        frame.MakeRoll();

        // Assert : le score doit être exactement le nombre de quilles tombées.
        Assert.AreEqual(4, frame.Score);
    }

    [TestMethod]
    public void Roll_SimpleFrame_SecondRoll_CheckScore()
    {
        // SUJET : "En série standard, le second lancer doit augmenter le score"
        //
        // Ici on simule qu'il reste 6 quilles (donc le premier lancer était 4).
        // On force RandomPin(6) à retourner 4.
        Mock.Get(generateur).Setup(x => x.RandomPin(6)).Returns(4);

        frame = new Frame(generateur, false);

        // Arrange : on "pré-charge" l'état interne pour simuler un premier lancer déjà fait.
        // Rolls = [4] => il reste 6 quilles possibles pour le second lancer.
        frame.Rolls = new List<Roll> { new Roll(4) };

        // Act : on fait le 2e lancer
        frame.MakeRoll();

        // Assert : score total = 4 (déjà présent) + 4 (nouveau lancer) = 8
        Assert.AreEqual(8, frame.Score);
        
    }

    [TestMethod]
    public void Roll_SimpleFrame_SecondRoll_FirstRollStrick_ReturnFalse()
    {
        // SUJET : "En cas de strike, il ne doit pas être possible de lancer de nouveau
        // au cours de cette même série (frame standard)."
        //
        // Peu importe la valeur mockée ici : on ne devrait même pas pouvoir relancer.
        Mock.Get(generateur).Setup(x => x.RandomPin(4)).Returns(4);

        frame = new Frame(generateur, false);

        // Arrange : premier lancer = 10 => strike
        frame.Rolls = new List<Roll> { new Roll(10) };

        // Act : tentative de lancer "en plus"
        bool res = frame.MakeRoll();

        // Assert : MakeRoll renvoie false => pas de relance possible (frame terminée).
        Assert.IsFalse(res);
    }

    [TestMethod]
    public void Roll_SimpleFrame_MoreRolls_ReturnFalse()
    {
        // SUJET : "En cas de lancers standards, il ne doit pas être possible de lancer plus de 2 fois"
        //
        // On simule qu'il y a déjà 2 lancers dans une frame standard.
        Mock.Get(generateur).Setup(x => x.RandomPin(4)).Returns(4);

        frame = new Frame(generateur, false);

        // Arrange : deux lancers déjà faits => frame normale terminée
        frame.Rolls = new List<Roll> { new Roll(4), new Roll(5) };

        // Act : tentative d'un 3e lancer
        bool res = frame.MakeRoll();

        // Assert : interdit
        Assert.IsFalse(res);
        
    }

    [TestMethod]
    public void Roll_LastFrame_MoreRolls_ReturnFalse()
    {
        // SUJET (dernière frame) : "En cas de lancers standards, il ne doit pas être possible
        // de lancer plus de 2 fois" (donc si pas strike/spare, pas de bonus)
        //
        // Ici : 4 + 5 = 9 => ni strike, ni spare => pas de 3e lancer.
        Mock.Get(generateur).Setup(x => x.RandomPin(4)).Returns(4);

        frame = new Frame(generateur, true);

        // Arrange : deux lancers "normaux" sans spare
        frame.Rolls = new List<Roll> { new Roll(4), new Roll(5) };

        // Act : tentative 3e lancer
        bool res = frame.MakeRoll();

        // Assert : interdit
        Assert.IsFalse(res);
    }

    [TestMethod]
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_ReturnTrue()
    {
        // SUJET (dernière frame) : "En cas de strike, il doit être possible de lancer une nouvelle fois"
        Mock.Get(generateur).Setup(x => x.RandomPin(4)).Returns(4);

        frame = new Frame(generateur, true);

        // Arrange : strike dès le premier lancer
        frame.Rolls = new List<Roll> { new Roll(10) };

        // Act : tentative de lancer bonus (2e lancer)
        bool res = frame.MakeRoll();

        // Assert : autorisé (true)
        Assert.IsTrue(res);
    }

    [TestMethod]
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_CheckScore()
    {
        // SUJET : "En cas de strike puis de lancer, le score augmente selon le résultat du lancer"
        //
        // Ici : 10 (strike déjà présent) + 4 (nouveau lancer) = 14
        Mock.Get(generateur).Setup(x => x.RandomPin(10)).Returns(4);

        frame = new Frame(generateur, true);
        frame.Rolls = new List<Roll> { new Roll(10) };

        frame.MakeRoll();

        Assert.AreEqual(14, frame.Score);
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_ReturnTrue()
    {
        // SUJET : "En cas de strike puis d’un lancer, il doit être possible de lancer une nouvelle fois"
        //
        // Frame dernière + strike => on peut aller jusqu'à un 3e lancer.
        Mock.Get(generateur).Setup(x => x.RandomPin(4)).Returns(4);

        frame = new Frame(generateur, true);

        // Arrange : strike puis 6
        frame.Rolls = new List<Roll> { new Roll(10), new Roll(6) };

        // Act : tentative 3e lancer
        bool res = frame.MakeRoll();

        // Assert : autorisé
        Assert.IsTrue(res);
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_CheckScore()
    {
        // SUJET : les lancers bonus ajoutent bien des points au score
        //
        // 10 + 6 + 4 = 20
        Mock.Get(generateur).Setup(x => x.RandomPin(4)).Returns(4);

        frame = new Frame(generateur, true);
        frame.Rolls = new List<Roll> { new Roll(10), new Roll(6) };

        frame.MakeRoll();

        Assert.AreEqual(20, frame.Score);
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_Spare_ReturnTrue()
    {
        // SUJET (dernière frame) : "En cas de spare, il doit être possible de lancer une nouvelle fois"
        Mock.Get(generateur).Setup(x => x.RandomPin(10)).Returns(4);

        frame = new Frame(generateur, true);

        // Arrange : 4 + 6 = 10 => spare
        frame.Rolls = new List<Roll> { new Roll(4), new Roll(6) };

        // Act : lancer bonus (3e lancer)
        bool res = frame.MakeRoll();

        // Assert : autorisé
        Assert.IsTrue(res);
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_Spare_CheckScore()
    {
        // SUJET : "En cas de spare puis de lancer, le score augmente en accord avec le résultat"
        //
        // 4 + 6 + 4 = 14
        Mock.Get(generateur).Setup(x => x.RandomPin(10)).Returns(4);

        frame = new Frame(generateur, true);
        frame.Rolls = new List<Roll> { new Roll(4), new Roll(6) };

        frame.MakeRoll();

        Assert.AreEqual(14, frame.Score);
    }

    [TestMethod]
    public void Roll_LastFrame_FourthRoll_ReturnFalse()
    {
        // SUJET (tel qu'implémenté par les tests) :
        // Dernière frame => maximum 3 lancers (2 + 1 bonus si spare/strike).
        //
        // Ici on a déjà 3 lancers, donc un 4e doit être refusé.
        Mock.Get(generateur).Setup(x => x.RandomPin(10)).Returns(4);

        frame = new Frame(generateur, true);

        // Arrange : spare (4+6) puis bonus (4) => 3 lancers déjà faits
        frame.Rolls = new List<Roll> { new Roll(4), new Roll(6), new Roll(4) };

        // Act : tentative 4e lancer
        bool res = frame.MakeRoll();

        // Assert : interdit
        Assert.IsFalse(res);
    }
}
