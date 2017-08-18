using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
    }
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }

    [TestMethod]
    public void Save_SavesNewClientInfo_Void()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, 1111111111);
      newClient.Save();

      int expected = 1;
      int actual = Client.GetAllClients().Count;

      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void GetAll_ReturnsAllClients_Void()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, 1111111111);
      newClient.Save();

      List<Client> expected = new List<Client> {newClient};
      List<Client> actual = Client.GetAllClients();

      CollectionAssert.AreEqual(expected, actual);
    }
  }
}
