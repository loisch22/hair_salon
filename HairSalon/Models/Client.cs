using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _clientName;
    // private date _apptDate;
    private string _hairType;
    private string _gender;
    private int _stylistId;
    private int _phoneNumber;

    public Client(string clientName, string hairType, string gender, int stylistId, int id = 0)
    {
      _clientName = clientName;
      _hairType = hairType;
      _gender = gender;
      _stylistId = stylistId;
      _phoneNumber = phoneNumber;
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
         bool idEquality = (this.GetId() == Client.GetId());
         bool nameEquality = (this.GetClientName() == newClient.GetStylistName());
         return (idEquality && nameEquality);
       }
     }

     public override int GetHashCode()
     {
       return this.GetClienttName().GetHashCode();
     }


  }
}
