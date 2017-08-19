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
    public void GetAllStylists_CategoriesEmptyAtFirst_0()
    {
      int result = Stylist.GetAllStylists().Count;

      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameName_Stylist()
    {
      Stylist firstStylist = new Stylist("Meg", 3, "Gene Juarez");
      Stylist secondStylist = new Stylist("Meg", 3, "Gene Juarez");

      Assert.AreEqual(firstStylist, secondStylist);
    }
    //
    // [TestMethod]
    // public void Save_StylistAreSaved_Void()
    // {
    //   Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez");
    //   newStylist.Save();
    //
    //   int expected = 1;
    //   int actual = Stylist.GetAllStylists().Count;
    //
    //   Assert.AreEqual(expected, actual);
    // }
    //
    // [TestMethod]
    // public void GetAll_ReturnAllStylistAdded_AllClientsList()
    // {
    //   Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez");
    //   newStylist.Save();
    //
    //   List<Stylist> expected = new List<Stylist> {newStylist};
    //   List<Stylist> actual = Stylist.GetAllStylists();
    //
    //   CollectionAssert.AreEqual(expected, actual);
    // }
    //
    // [TestMethod]
    // public void FindStylistInfo_ReturnsStylistDetails_ClientList()
    // {
    //   Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez", 1);
    //   newStylist.Save();
    //   int stylistId = newStylist.GetId();
    //
    //   Stylist expected = newStylist;
    //   Stylist actual = Stylist.FindStylistInfo(stylistId);
    //
    //   Assert.AreEqual(expected, actual);
    // }
    //
    // [TestMethod]
    // public void DeleteAll_DeleteAllStylists_Void()
    // {
    //   Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez", 1);
    //   newStylist.Save();
    //   Stylist.DeleteAll();
    //
    //   int expected = 0;
    //   int actual = Stylist.GetAllStylists().Count;
    //
    //   Assert.AreEqual(expected, actual);
    // }
    //
    // [TestMethod]
    // public void DeleteStylist_DeletesSpecificStylist_Void()
    // {
    //   Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez", 1);
    //   newStylist.Save();
    //   Stylist newStylist2 = new Stylist("Meg", 3, "Gene Juarez", 1);
    //   newStylist2.Save();
    //   int stylistId = newStylist.GetId();
    //   Stylist.DeleteStylist(stylistId);
    //
    //   bool expected = false;
    //   bool actual = Stylist.GetAllStylists().Contains(newStylist);
    //
    //   Assert.AreEqual(expected, actual);
    // }
    //
    // [TestMethod]
    // public void UpdateStylist_UpdatesStylistName_Void()
    // {
    //   Stylist newStylist = new Stylist("Meg", 3, "Gene Juarez", 1);
    //   newStylist.Save();
    //   Stylist newStylist2 = new Stylist("Meg", 3, "Gene Juarez", 1);
    //   newStylist.Save();
    //   newStylist2.Save();
    //   string newName = "Megan";
    //
    //   newStylist.UpdateStylist(newName);
    //
    //   Stylist expected = new Stylist("Megan", 3, "Gene Juarez", 1);;
    //   Stylist actual = Stylist.GetAllStylists()[0];
    //   Console.WriteLine(actual.GetStylistName());
    //
    //   Assert.AreEqual(expected, actual);
    // }
  }
}
