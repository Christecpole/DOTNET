namespace Exercices.Test;

[TestClass]
public class GradingCalculatorTest
{
    private GradingCalculator gradingCalculator;

    private void SetUp(int score,int attendancePercentage)
    {
        gradingCalculator = new GradingCalculator()
        {
            Score = score,
            AttendancePercentage = attendancePercentage
        };
    }

    //    - Score : 95%, Présence : 90 => Note: A
    [TestMethod]
    public void WhenGetGrade_95_90_Then_A()
    {
        // Arrange
        //GradingCalculator gradingCalculator = new GradingCalculator()
        //{
        //    Score = 95,
        //    AttendancePercentage = 90,
        //};
        //gradingCalculator.Score = 95;
        //gradingCalculator.AttendancePercentage = 90;

        // equivalent avec une methode SetUp
        SetUp(95, 90);

        // Act
        char c = gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('A', c);

    }


    //- Score : 85%, Présence : 90 => Note: B
    [TestMethod]
    public void WhenGetGrade_85_90_Then_B()
    {
        // Arrange
        GradingCalculator gradingCalculator = new GradingCalculator()
        {
            Score = 85,
            AttendancePercentage = 90,
        };

        // Act
        char c = gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('B', c);

    }
    //- Score : 65%, Présence : 90 => Note: C
    [TestMethod]
    public void WhenGetGrade_65_90_Then_C()
    {
        // Arrange
        GradingCalculator gradingCalculator = new GradingCalculator()
        {
            Score = 65,
            AttendancePercentage = 90,
        };

        // Act
        char c = gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('C', c);

    }
    //- Score : 95%, Présence : 65 => Note: B
    [TestMethod]
    public void WhenGetGrade_95_65_Then_B()
    {
        // Arrange
        GradingCalculator gradingCalculator = new GradingCalculator()
        {
            Score = 95,
            AttendancePercentage = 65,
        };

        // Act
        char c = gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('B', c);

    }
    //- Score : 95%, Présence : 55 => Note: F
    [TestMethod]
    public void WhenGetGrade_95_55_Then_F()
    {
        // Arrange
        GradingCalculator gradingCalculator = new GradingCalculator()
        {
            Score = 95,
            AttendancePercentage = 55,
        };

        // Act
        char c = gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('F', c);

    }
    //- Score : 65%, Présence : 55 => Note: F
    [TestMethod]
    public void WhenGetGrade_65_55_Then_F()
    {
        // Arrange
        GradingCalculator gradingCalculator = new GradingCalculator()
        {
            Score = 65,
            AttendancePercentage = 55,
        };

        // Act
        char c = gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('F', c);

    }
    //- Score : 50%, Présence : 90 => Note: F
    [TestMethod]
    public void WhenGetGrade_50_90_Then_F()
    {
        // Arrange
        GradingCalculator gradingCalculator = new GradingCalculator()
        {
            Score = 50,
            AttendancePercentage = 90,
        };

        // Act
        char c = gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('F', c);

    }

    [TestMethod]
    [DataRow(95,90,'A')]
    [DataRow(85,90,'B')]
    [DataRow(65,90,'C')]
    [DataRow(95,65,'B')]
    [DataRow(95,55,'F')]
    [DataRow(65,55,'F')]
    [DataRow(50,90,'F')]
    public void WhenGetGrade(int score,int pres,char note)
    {
        SetUp(score, pres);
        char c = gradingCalculator.GetGrade();
        Assert.AreEqual(note, c);
    
    }
}
