using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _clientName;
    private string _hairType;
    private string _gender;
    private int _stylistId;
    private int _phoneNumber;

    public Client(string clientName, string hairType, string gender, int stylistId, int phoneNumber, int id = 0)
    {
      _id = id;
      _clientName = clientName;
      _hairType = hairType;
      _gender = gender;
      _stylistId = stylistId;
      _phoneNumber = phoneNumber;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetClientName()
    {
      return _clientName;
    }

    public string GetHairType()
    {
      return _hairType;
    }

    public string GetGender()
    {
      return _gender;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public int GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public override bool Equals(Object otherClient)
    {
       if (!(otherClient is Client))
       {
         return false;
       }
       else
       {
         Client newClient = (Client) otherClient;
         bool idEquality = (this.GetId() == newClient.GetId());
         bool nameEquality = (this.GetClientName() == newClient.GetClientName());
         return (idEquality && nameEquality);
       }
     }

    public override int GetHashCode()
    {
     return this.GetClientName().GetHashCode();
    }

    public static List<Client> GetStylistClients(int searchStylist)
    {
      List<Client> stylistClients = new List<Client> {};

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";

      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@stylist_id";
      stylistIdParameter.Value = searchStylist;
      cmd.Parameters.Add(stylistIdParameter);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string hairType = rdr.GetString(2);
        string gender = rdr.GetString(3);
        int stylistId = rdr.GetInt32(4);
        int phoneNumber = rdr.GetInt32(5);
        Client clientMatch = new Client(clientName, hairType, gender, stylistId, phoneNumber, id);
        stylistClients.Add(clientMatch);
      }
      conn.Close();
      return stylistClients;
    }

    public static Client FindClientInfo(int clientId)
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = @id;";

      MySqlParameter clientIdParameter = new MySqlParameter();
      clientIdParameter.ParameterName = "@id";
      clientIdParameter.Value = clientId;
      cmd.Parameters.Add(clientIdParameter);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      Client foundClient = new Client("", "", "", 0, 0);

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string hairType = rdr.GetString(2);
        string gender = rdr.GetString(3);
        int stylistId = rdr.GetInt32(4);
        int phoneNumber = rdr.GetInt32(5);
        foundClient = new Client(clientName, hairType, gender, stylistId, phoneNumber, id);
      }
      conn.Close();
      return foundClient;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients(client_name, hair_type, gender, stylist_id, phone_number) VALUES (@client_name, @hair_type, @gender, @stylist_id, @phone_number);";

      MySqlParameter clientNameParameter = new MySqlParameter();
      clientNameParameter.ParameterName = "@client_name";
      clientNameParameter.Value = this._clientName;
      cmd.Parameters.Add(clientNameParameter);

      MySqlParameter hairTypeParameter = new MySqlParameter();
      hairTypeParameter.ParameterName = "@hair_type";
      hairTypeParameter.Value = this._hairType;
      cmd.Parameters.Add(hairTypeParameter);

      MySqlParameter genderParameter = new MySqlParameter();
      genderParameter.ParameterName = "@gender";
      genderParameter.Value = this._gender;
      cmd.Parameters.Add(genderParameter);

      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@stylist_id";
      stylistIdParameter.Value = this._stylistId;
      cmd.Parameters.Add(stylistIdParameter);

      MySqlParameter phoneNumberParameter = new MySqlParameter();
      phoneNumberParameter.ParameterName = "@phone_number";
      phoneNumberParameter.Value = this._phoneNumber;
      cmd.Parameters.Add(phoneNumberParameter);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
    }

    public static List<Client> GetAllClients()
    {
      List<Client> allClients = new List<Client> {};

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string hairType = rdr.GetString(2);
        string gender = rdr.GetString(3);
        int stylistId = rdr.GetInt32(4);
        int phoneNumber = rdr.GetInt32(5);
        Client newClient = new Client(clientName, hairType, gender, stylistId, phoneNumber);
        allClients.Add(newClient);
      }
      conn.Close();
      return allClients;
    }

    public static void DeleteClient(int clientId)
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @id;";

      MySqlParameter clientIdParameter = new MySqlParameter();
      clientIdParameter.ParameterName = "@id";
      clientIdParameter.Value = clientId;
      cmd.Parameters.Add(clientIdParameter);

      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"TRUNCATE TABLE clients;";

      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
