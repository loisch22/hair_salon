# _Hair Salon_

#### _An application that allow stylists to add themselves, then to add, remove, and keep track of their scheduled clients, August 18, 2017_

#### By _**Lois Choi**_

## Description

_This application will allow hair salon employees to view, add, and delete clients scheduled._

## Setup for Hair Salon SQL Database

* CREATE DATABASE hair_salon;
* SHOW DATABASES;
* USE hair_salon;
* CREATE TABLE clients (id serial PRIMARY KEY, client_name VARCHAR(255), hair_type VARCHAR(255), gender VARCHAR(255), stylist_id INT);
* CREATE TABLE stylists (id serial PRIMARY KEY, stylist_name VARCHAR(255), experience INT, education VARCHAR(255));

## User Story Specifications (BDD)

| Behavior | Input | Output |
| :---         |     :---:      |          ---: |
| 1. Owner can add a new stylists when hired | > Start    | Add stylist Form    |
| 2. Owner or stylist can view a list of all stylists, newly added stylist is shown on the list | Add stylist Meg <br> Add stylist Carly | > Meg <br> > Carly |
| 3. Owner or stylist can click on a stylist name, view stylist info | > Click Meg | Name: Meg Years Experience: 3 Education: Gene Juarez |
| 4. Owner or stylist can add a new client | > Click Meg <br> > ADD NEW CLIENT Stylist: Meg Client: Cindy, 8/20/2017, wavy, female, 111-111-1111   |  Stylist Meg's Page with Cindy added |
| 5. Owner or stylist can view a clients details by clicking on the clients name | > Cindy | Stylist: Meg Client: Cindy, 8/20/2017, wavy, female, 205-111-2222  |
| 6. Owner or stylist can click on a stylist name, view stylist info and their client list | > Click Meg | Name: Meg Years Experience: 3 Education: Gene Juarez <br> Clients: Cindy |
| 7. Owner or stylist can delete all stylists and/or clients | DELETE Stylist <br> DELETE clients | There are no stylists <br> There are no clients |
| 8. Owner or stylist can delete a specific stylist or client | DELETE: Meg from list (Meg Carly)| View: Carly |
| 9. Owner or stylist can update a client or stylist name | UPDATE Client: Cindy to CiCi <br> UPDATE stylist: Meg to Megan | View Client: CiCi <br> View Stylist: Megan |

## Known Bugs

_Can't add new client from client list._
_UI can be improved when adding new client from list of no clients, also have the exit button go back to list of stylist instead of home from that same page._


## Technologies Used

_C#, SQL, .NET_

### License

*MIT License*

Copyright (c) 2017 **_Lois Choi_**
