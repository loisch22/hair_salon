using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/stylist/form")]
    public ActionResult StylistForm()
    {
      return View();
    }
    [HttpPost("/new/stylist")]
    public ActionResult NewStylist()
    {
      string newName = Request.Form["stylistName"];
      int experience = int.Parse(Request.Form["experience"]);
      string education = Request.Form["education"];

      Stylist newStylist = new Stylist(newName, experience, education);
      newStylist.Save();

      return View(newStylist);
    }

    [HttpGet("/stylist/list")]
    public ActionResult StylistList()
    {
      List<Stylist> allStylist = Stylist.GetAllStylists();

      return View(allStylist);
    }

    [HttpGet("/stylist/info/{id}")]
    public ActionResult StylistInfo(int id)
    {
      Stylist stylistInfo = Stylist.FindStylistInfo(id);

      return View(stylistInfo);
    }

    [HttpGet("/add/client/{id}")]
    public ActionResult AddClient(int id)
    {
      Stylist stylistInfo = Stylist.FindStylistInfo(id);

      return View(stylistInfo);
    }

    [HttpPost("/stylist/{id}/info/client")]
    public ActionResult ViewStylistClients(int id)
    {
      string clientName = Request.Form["clientName"];
      string hairType = Request.Form["hairType"];
      string gender = Request.Form["gender"];
      string phoneNumber = Request.Form["phoneNumber"];

      Client newClient = new Client(clientName, hairType, gender, id, phoneNumber);
      newClient.Save();
      int stylistId = newClient.GetStylistId();

      List<Client> allStylistClients = Client.GetStylistClients(stylistId);

      return View(allStylistClients);
    }

    [HttpGet("/stylist/{id}/info/client")]
    public ActionResult ViewClientList(int id)
    {
      List<Client> clientList = Client.GetStylistClients(id);

      return View();
    }

    [HttpGet("/client/details/{id}")]
    public ActionResult ClientDetail(int id)
    {
      Client clientDetails = Client.FindClientInfo(id);
      return View(clientDetails);
    }

    [HttpGet("/view/all/clients/{id}")]
    public ActionResult ViewClientsForStylist(int id)
    {
      List<Client> clientList = Client.GetStylistClients(id);

      return View(clientList);
    }

    [HttpGet("/delete/all/clients")]
    public ActionResult DeleteAllClients()
    {
      Client.DeleteAll();

      List<Client> newList = Client.GetAllClients();

      return View("StylistList", newList);
    }

    [HttpGet("/delete/all/stylists")]
    public ActionResult DeleteAllCStylists()
    {
      Stylist.DeleteAll();

      List<Stylist> newList = Stylist.GetAllStylists();

      return View("StylistList", newList);
    }

    [HttpGet("/delete/client/{id}")]
    public ActionResult DeleteClient(int id)
    {
      Client.DeleteClient(id);

      List<Client> newList = Client.GetAllClients();

      return View("StylistList", newList);
    }

    [HttpGet("/update/client/{id}")]
    public ActionResult UpdateClient(int id)
    {
      Client searchClient = Client.FindClientInfo(id);
      return View(searchClient);
    }

    [HttpPost("/update/client/{id}")]
    public ActionResult UpdateClientPost(int id)
    {
      Client searchClient = Client.FindClientInfo(id);

      string newName = Request.Form["newName"];
      searchClient.UpdateClient(newName);

      Client updatedName = Client.FindClientInfo(id);

      return View("ClientDetail", updatedName);
    }

  }
}
