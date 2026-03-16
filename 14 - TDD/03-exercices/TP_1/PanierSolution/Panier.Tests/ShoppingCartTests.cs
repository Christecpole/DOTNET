using Panier.Core;

namespace Panier.Tests;

[TestClass]
public class ShoppingCartTests
{
    private ShoppingCart? _cart;

    [TestInitialize]
    public void SetUp()
    {
        _cart = new ShoppingCart();
    }

    [TestCleanup]
    public void TearDown()
    {
        _cart = null;
    }

    // * Un panier neuf contient 0 article.
    [TestMethod]
    public void WhenNewCart_ThenItemCountIsZero()
    {
        int count = _cart!.GetItemCount();

        Assert.AreEqual(0, count);
    }


    // * Un panier vide a un total égal à 0.
    [TestMethod]
    public void WhenNewCart_ThenTotalIsZero()
    {
        decimal total = _cart!.GetTotal();

        Assert.AreEqual(0m, total);
    }

    // * Appliquer une remise sur un panier vide déclenche une exception.
    [TestMethod]
    public void WhenApplyDiscountOnEmptyCart_ThenThrowsInvalidOperationException()
    {
        Assert.ThrowsExactly<InvalidOperationException>(() => _cart!.ApplyDiscount(10m));
    }


    // * Ajouter un article valide augmente le nombre d’articles.
    [TestMethod]
    public void WhenAddValidItem_ThenItemCountIncreases()
    {
        _cart!.AddItem("Apple", 1.50m, 2);

        int count = _cart.GetItemCount();

        Assert.AreEqual(1, count);
    }


    // * Ajouter un article avec nom invalide déclenche une exception.
    [TestMethod]
    public void WhenAddItemWithEmptyName_ThenThrowsArgumentException()
    {
        Assert.ThrowsExactly<ArgumentException>(() => _cart!.AddItem("", 1.50m, 1));
    }


    // * Ajouter un article avec nom invalide déclenche une exception.
    [TestMethod]
    public void WhenAddItemWithNullName_ThenThrowsArgumentException()
    {
        Assert.ThrowsExactly<ArgumentException>(() => _cart!.AddItem(null!, 1.50m, 1));
    }

    // * Ajouter un article avec prix ≤ 0 déclenche une exception.
    [TestMethod]
    public void WhenAddItemWithNonPositivePrice_ThenThrowsArgumentException()
    {
        Assert.ThrowsExactly<ArgumentException>(() => _cart!.AddItem("Apple", 0m, 1));
        Assert.ThrowsExactly<ArgumentException>(() => _cart!.AddItem("Apple", -1m, 1));
    }


    // * Ajouter un article avec quantité ≤ 0 déclenche une exception.
    [TestMethod]
    public void WhenAddItemWithNonPositiveQuantity_ThenThrowsArgumentException()
    {

        Assert.ThrowsExactly<ArgumentException>(() => _cart!.AddItem("Apple", 1m, 0));
        Assert.ThrowsExactly<ArgumentException>(() => _cart!.AddItem("Apple", 1m, -1));
    }

    // * Un article → total = price × quantity.
    [TestMethod]
    public void WhenOneItem_ThenTotalIsPriceTimesQuantity()
    {
        _cart!.AddItem("Apple", 1.50m, 2);

        decimal total = _cart.GetTotal();

        Assert.AreEqual(3.00m, total);
    }

    // * Plusieurs articles → total = somme correcte.
    [TestMethod]
    public void WhenMultipleItems_ThenTotalIsSumOfLineTotals()
    {
        _cart!.AddItem("Apple", 1.50m, 2);
        _cart.AddItem("Bread", 2.00m, 1);
        _cart.AddItem("Milk", 1.25m, 3);

        decimal total = _cart.GetTotal();

        Assert.AreEqual(3.00m + 2.00m + 3.75m, total);
    }


    // * Appliquer 10% réduit correctement le total.
    [TestMethod]
    public void WhenApply10PercentDiscount_ThenTotalIsReduced()
    {
        _cart!.AddItem("Apple", 10m, 1);

        _cart.ApplyDiscount(10m);
        decimal total = _cart.GetTotal();

        Assert.AreEqual(9.0m, total);
    }

    // * Appliquer 0% ne change rien.
    [TestMethod]
    public void WhenApply0PercentDiscount_ThenTotalUnchanged()
    {
        _cart!.AddItem("Apple", 10m, 1);

        _cart.ApplyDiscount(0m);
        decimal total = _cart.GetTotal();

        Assert.AreEqual(10m, total);
    }

    // * Appliquer 100% donne 0.
    [TestMethod]
    public void WhenApply100PercentDiscount_ThenTotalIsZero()
    {
        _cart!.AddItem("Apple", 10m, 1);

        _cart.ApplyDiscount(100m);
        decimal total = _cart.GetTotal();

        Assert.AreEqual(0m, total);
    }

    // * Remise négative → exception.
    [TestMethod]
    public void WhenApplyNegativeDiscount_ThenThrowsArgumentOutOfRangeException()
    {
        _cart!.AddItem("Apple", 10m, 1);

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _cart.ApplyDiscount(-1m));
    }

    // * Remise > 100 → exception.
    [TestMethod]
    public void WhenApplyDiscountGreaterThan100_ThenThrowsArgumentOutOfRangeException()
    {
        _cart!.AddItem("Apple", 10m, 1);

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _cart.ApplyDiscount(101m));
    }

    // * Appliquer une remise deux fois → exception.
    [TestMethod]
    public void WhenApplyDiscountTwice_ThenThrowsInvalidOperationException()
    {
        _cart!.AddItem("Apple", 10m, 1);

        _cart.ApplyDiscount(10m);

        Assert.ThrowsExactly<InvalidOperationException>(() => _cart.ApplyDiscount(10m));
    }

}
