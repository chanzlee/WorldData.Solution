using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorldData.Models;

namespace WorldData.Tests
{

  [TestClass]
  public class CityTests : IDisposable
  {
    public void Dispose()
    {
        City.DeleteAll();
    }
    public CityTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }
    [TestMethod]
    public void GetAll_DbStartsEmpty_0()
    {
      //Arrange
      //Act
      int result = City.GetAll().Count;
      //Assert
      Assert.AreEqual(0, result);
    }
  }

  [TestClass]
  public class CountryTests : IDisposable
  {
    public void Dispose()
    {
        Country.DeleteAll();
    }
    public CountryTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }
    [TestMethod]
    public void GetAll_DbStartsEmpty_0()
    {
      //Arrange
      //Act
      int result = Country.GetAll().Count;
      //Assert
      Assert.AreEqual(0, result);
    }
  }
}
