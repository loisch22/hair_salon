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

    [HttpGet("/add/client")]
    public ActionResult AddClient()
    {
      return View();
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
      int phoneNumber = int.Parse(Request.Form["phoneNumber"]);

      Client newClient = new Client(clientName, hairType, gender, id, phoneNumber);
      newClient.Save();
      int stylistId = newClient.GetStylistId();

      List<Client> allStylistClients = Client.GetStylistClients(stylistId);

      return View(allStylistClients);
    }

    [HttpGet("/client/details/{id}")]
    public ActionResult ClientDetail(int id)
    {
      Client clientDetails = Client.FindClientInfo(id);
      return View(clientDetails);
    }

  }
}
