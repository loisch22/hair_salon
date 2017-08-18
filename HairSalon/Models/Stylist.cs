using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int id;
    private string _stylistName;
    private string _experience;
    private string _education;

    public Stylist(string stylistName, string experience, string education, int id = 0)
    {
      _id = id;
      _stylistName = stylistName;
      _experience = experience;
      _education = education;
    }

    public override bool Equals(Object otherStylist)
    {
       if (!(otherStylist is Stylist))
       {
         return false;
       }
       else
       {
         Stylist newStylist = (Stylist) otherStylist;
         bool idEquality = (this.GetId() == Stylist.GetId());
         bool nameEquality = (this.GetStylistName() == newStylist.GetStylistName());
         return (idEquality && nameEquality);
       }
     }

     public override int GetHashCode()
     {
       return this.GetStylistName().GetHashCode();
     }

    public int GetId()
    {
      return _id;
    }

    public string GetStylistName()
    {
      return _stylistName;
    }

    public string GetStylistExperience()
    {
      return _experience;
    }

    public string GetStylistEdu()
    {
      return _education;
    }

    public static List<Stylist> GetAll()
    {

    }

    public static List<Stylist> DeleteAll()
    {

    }

  }
}
