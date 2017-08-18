using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _stylistName;
    private int _experience;
    private string _education;

    public Stylist(string stylistName, int experience, string education, int id = 0)
    {
      _id = id;
      _stylistName = stylistName;
      _experience = experience;
      _education = education;
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

    public override bool Equals(Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool nameEquality = (this.GetStylistName() == newStylist.GetStylistName());
        return (idEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetStylistName().GetHashCode();
    }

    public static Stylist FindStylistInfo(int stylidId)
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @id;";

      MySqlParameter stylistInfoParameter = new MySqlParameter();
      stylistInfoParameter.ParameterName = "@id";
      stylistInfoParameter.Value = stylidId;
      cmd.Parameters.Add(stylistInfoParameter);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      Stylist foundStylist = new Stylist("", 0, "");

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int experience = rdr.GetInt32(2);
        string education = rdr.GetString(3);
        foundStylist = new Stylist (name, experience, education, id);
      }
      conn.Close();
      return foundStylist;
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
      cmd.Parameters.Add(stylistExperienceParameter);

      MySqlParameter stylistEducationParameter  = new MySqlParameter();
      stylistEducationParameter.ParameterName = "@education";
      stylistEducationParameter.Value = this._education;
      cmd.Parameters.Add(stylistEducationParameter);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
    }

    public static List<Stylist> GetAllStylist()
    {
      List<Stylist> allStylist = new List<Stylist> {};

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int stylist_id = rdr.GetInt32(0);
        string stylist_name = rdr.GetString(1);
        int experience = rdr.GetInt32(2);
        string education = rdr.GetString(3);
        Stylist newStylist = new Stylist(stylist_name, experience, education, stylist_id);
        allStylist.Add(newStylist);
        // cmd.ExecuteQuery();
      }
      conn.Close();
      return allStylist;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"TRUNCATE TABLE stylists;";

      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
