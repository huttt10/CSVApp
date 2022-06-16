using CSVApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVAppTests;

[TestClass]
public class DatabaseTests
{
    // Name - TestedMethod_Scenario_ExpectedResult   Example - CanBeCancelled_UserIsAdmin_ReturnTrue
    [TestMethod]
    public void IsInGoodFormat_StringIsOK_ReturnTrue()
    {
        // Arrange
        string input = "Karel,40";
        Database db = new Database("test.csv");

        // Act
        var test = db.IsInGoodFormat(input);


        // Assert
        Assert.IsTrue(test);

    }

    [TestMethod]
    public void IsInGoodFormat_StringIsLonger_ReturnFalse()
    {
        string input = "Karel,50,40";
        Database db = new Database("test.csv");

        var test = db.IsInGoodFormat(input);

        Assert.IsFalse(test);
    }

    [TestMethod]
    public void IsInGoodFormat_StringIsShorter_ReturnFalse()
    {
        string input = "Karel";
        Database db = new Database("test.csv");

        var test = db.IsInGoodFormat(input);

        Assert.IsFalse(test);
    }

    [TestMethod]
    public void IsInGoodFormat_StringIsNull_ReturnFalse()
    {
        string input = null;
        Database db = new Database("test.csv");

        var test = db.IsInGoodFormat(input);

        Assert.IsFalse(test);
    }
}