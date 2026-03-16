using Demo02TDD.Core;
using System.Text;

namespace Demo02TDD.Tests;

[TestClass]
public class LeapTesterTest
{

    /*
    On souhaite développer une application qui nous permet de connaître si une année est bissextile

    Les critères pour une années sont :

    - Une année divisible par 400.
    - Une année divisible par 4 mais pas par 100.
    - Une année n'est pas divisible par 4000.

    Le développement doit se faire en TDD
    */


    //- Une année divisible par 400.
    [TestMethod]
    [DataRow(400)]
    [DataRow(1200)]
    public void TestLeap_400_ShouldBe_True(int year)
    {
        LeapTester tester = new LeapTester();

        bool res = tester.IsLeap(year);

        Assert.IsTrue(res);
    }


    //- Une année divisible par 4 mais pas par 100.
    [TestMethod]
    [DataRow(12)]
    [DataRow(404)]
    public void TestLeap_4_Not_100_ShouldBe_True(int year)
    {
        LeapTester lt = new();

        bool res = lt.IsLeap(year);

        Assert.IsTrue(res);
    }

    // - Une année n'est pas divisible par 4000.
    [TestMethod]
    [DataRow(8000)]
    [DataRow(12000)]
    public void TestLeap_4000_ShouldBe_False(int year)
    {
        LeapTester lt = new();

        bool res = lt.IsLeap(year);

        Assert.IsFalse(res);
    }


    [TestMethod]
    public void TestLeap_Others_ShouldBe_False()
    {
        LeapTester lt = new LeapTester();

        bool res = lt.IsLeap(1999);
        Assert.IsFalse(res);
    }
}
