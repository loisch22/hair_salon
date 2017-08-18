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
  }
}
