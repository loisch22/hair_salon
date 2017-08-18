using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int id;
    private string _stylistName;
    private int _experience;
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

    public int GetStylistExperience()
    {
      return _experience;
    }

    public string GetStylistEdu()
    {
      return _education;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists(stylist_name, experience, education) VALUES (@stylistName, @experience, @education);";

      MySqlParameter stylistNameParameter  = new MySqlParameter();
      stylistNameParameter.ParameterName = "@stylistName";
      stylistNameParameter.Value = this._stylistName;
      cmd.Parameters.Add(stylistNameParameter);

      MySqlParameter stylistExperienceParameter = new MySqlParameter();
      stylistExperienceParameter.ParameterName = "@experience";
      stylistExperienceParameter.Value = this._experience;
      cmd.Parameter.Add(stylistExperienceParameter);

      MySqlParameter stylistEducationParameter  = new MySqlParameter();
      stylistEducationParameter.ParameterName = "@education";
      stylistEducationParameter.Value = this._education;
      cmd.Parameters.Add(stylistEducationParameter);

      cmd.ExecuteNonQuery();
      id = (int) cmd.LastInsertedId;
      conn.Close();
    }

    public static List<Stylist> GetAllStylist()
    {

    }

    public static List<Stylist> DeleteAll()
    {

    }

  }
}
