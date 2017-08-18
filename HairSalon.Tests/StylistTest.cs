using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }

    [TestMethod]
    public void Save_StylistAreSaved_Void()
    {
      Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez");
      newStylist.Save();

      int expected = 1;
      int actual = Stylist.GetAllStylist().Count;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAll_ReturnAllStylistAdded_Void()
    {
      Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez");
      newStylist.Save();

      List<Stylist> expected = new List<Stylist> {newStylist};
      List<Stylist> actual = Stylist.GetAllStylist();

      CollectionAssert.AreEqual(expected, actual);
    }
  }
}
