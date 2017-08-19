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
    public void GetAllClients_ClientsEmptyFirst_0()
    {
      int result = Client.GetAllClients().Count;

      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameName_Clients()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, "1111111111");
      Client newClient2 = new Client("Cindy", "wavy", "female", 1, "1111111111");

      Assert.AreEqual(newClient, newClient2);
    }
    [TestMethod]
    public void Save_SavesNewClientInfo_Void()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, "1111111111");
      newClient.Save();

      int expected = 1;
      int actual = Client.GetAllClients().Count;

      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Save_DatabaseAssignsIdToClients_Id()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, "1111111111");
      newClient.Save();

      Client savedClient = Client.GetAllClients()[0];

      int expected = savedClient.GetId();
      int actual = newClient.GetId();
    }
    [TestMethod]
    public void GetAllClients_ReturnsAllClients_ClientList()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, "1111111111");
      newClient.Save();

      int expected = 1;
      int actual = Client.GetAllClients().Count;

      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FindClientInfo_ReturnsASpecificClientsInfo_ClientInfo()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, 1111111111);
      newClient.Save();
      int stylistId = newClient.GetStylistId();

      Client expected = newClient;
      Client actual = Client.FindClientInfo(stylistId);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetStylistClients_ReturnClientsThatBelongToSameStylist_ClientList()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, 1111111111);
      newClient.Save();
      int searchStylist = newClient.GetStylistId();

      List<Client> expected = new List<Client> {newClient};
      List<Client> actual = Client.GetStylistClients(searchStylist);

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DeleteAll_DeleteAllClients_Void()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, 1111111111);
      newClient.Save();

      Client.DeleteAll();

      int expected = 0;
      int actual = Client.GetAllClients().Count;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DeleteClient_DeletesSpecificClient_Void()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, 1111111111);
      Client newClient2 = new Client("Cindy", "wavy", "female", 1, 1111111111);
      newClient.Save();
      newClient2.Save();
      int clientId = newClient.GetId();
      Client.DeleteClient(clientId);

      bool expected = false;
      bool actual = Client.GetAllClients().Contains(newClient);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void UpdateClient_UpdatesClientName_Void()
    {
      Client newClient = new Client("Cindy", "wavy", "female", 1, 1111111111);
      Client newClient2 = new Client("Cindy", "wavy", "female", 1, 1111111111);
      newClient.Save();
      newClient2.Save();
      string newName = "CiCi";

      newClient.UpdateClient(newName);

      Client expected = new Client("CiCi", "wavy", "female", 1, "1111111111");;
      Client actual = Client.GetAllClients()[0];

      Assert.AreEqual(expected, actual);
    }
  }
}
