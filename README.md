# _Hair Salon_

#### _An application that allow stylists to add themselves, then to add, remove, and keep track of their scheduled clients, August 18, 2017_

#### By _**Lois Choi**_

## Description

_This application will allow hair salon employees to view, add, and delete clients scheduled._

## Setup for Hair Salon SQL Database

* CREATE DATABASE hair_salon;
* SHOW DATABASES;
* USE hair_salon;
* CREATE TABLE clients (id serial PRIMARY KEY, client_name VARCHAR(255), appt_date DATE, hair_type VARCHAR(255), gender VARCHAR(255), stylist_id INT);
* CREATE TABLE stylists (id serial PRIMARY KEY, stylist_name VARCHAR(255), experience INT, education VARCHAR(255));

## User Story Specifications (BDD)

| Behavior | Input | Output |
| :---         |     :---:      |          ---: |
| 1. Owner can add a new stylists when hired | > Start    | Add stylist Form    |
| 2. Owner or stylist can view a list of all stylists, newly added stylist is shown on the list | Add stylist Meg <br> Add stylist Carly | > Meg <br> > Carly |
| 3. Owner or stylist can click on a stylist name, view stylist info, their client list, add a new client | > Click Meg <br> > ADD NEW CLIENT Stylist: Meg Client: Cindy, 8/20/2017, wavy, female, 111-111-1111   |  Stylist Meg's Page with Cindy added |
| 4. The newly added client is appended to stylist's client list | Stylist: Meg <br> Client: Cindy | Cindy |
| 5. Owner or stylist can view a clients details by clicking on the clients name | > Cindy | Stylist: Meg Client: Cindy, 8/20/2017, wavy, female, 205-111-2222  |
| 6. Owner or stylist can delete all stylists and/or clients | DELETE Stylist <br> DELETE clients | There are no stylists <br> There are no clients |
| 7. Owner or stylist can delete a specific stylist or client | DELETE: Meg from list (Meg Carly)| View: Carly |
| 8. Owner or stylist can update a client or stylist name | UPDATE Client: Cindy to CiCi <br> UPDATE stylist: Meg to Megan | View Client: CiCi <br> View Stylist: Megan |

## Known Bugs

_No known bugs_


## Technologies Used

_C#, SQL, .NET_

### License

*MIT License*

Copyright (c) 2017 **_Lois Choi_**
