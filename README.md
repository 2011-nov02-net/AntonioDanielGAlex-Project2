# AntonioDanielGAlex-Project2
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
This is the REST API portion the Angular Application can be found: 
https://github.com/2011-nov02-net/yourepic-project2

YourEpic Repository for Antonio, Daniel G and Alex.

[YourEpic Proposal](https://docs.google.com/document/d/110CFgocDz_p0YhPzczBU7uMoHWYTG94biJe4v2cDekM/edit#heading=h.c1t6sybq75mr)

[YourEpic App Flow](https://app.diagrams.net/#G1xj6OPHXfH8RLTnHg3TAtpzj1IJUDBFJW)

[YourEpic Route Diagram](https://app.diagrams.net/#G1r887OK-eMITdHS-oOsdHVwXAuKkiywR_)

## Project Description
YourEpic is an application that helps solve the "writers block" problem that writers know all too well. By signing up as a Publisher, a writer is able to create an "Epic" (an empty book), then add chapters as they create them instead of all at once. Signing up as a Reader allows a user to read these Epics-in-progress then subscribe to the Publisher, leave comments, or leave ratings. YourEpic is a unique choice because Publishers are able to receive feedback before they are done with their Epics, which they can use to reflect on their writing or determine any changes they would like to make.

## Technologies Used
* C#
* ADO.NET Entity Framework
* ASP.NET Web API
* DevOps
* Microsoft Azure
* SQL Server

## Features
Two User Types: Publishers and Readers

Readers
* View Epics
* Rate Epics
* Subscribe to Publishers
* Can Browse or Search site contents
* View public Rating

Publishers
* Create new Epics
* Modify existing ones
* Add Chapters to Epics
* Modify existing Chapters
* Categorize my Epic

Definitions\
	Reader - A user who cannot create content for the site, a readonly user.\
	Publisher - A user who can create content for the site, cannot view entire site.\
	Epic - A collection a user has created, can contain any amount of Chapters\
	Chapter - A single entity that contains a title and content

### To - Do
* We want users to be able to comment on Epics to start a discussio.
* Give more control to epics to the publishers, allowing for deletion.
* Publishers should have the ability to make Epics Private or Public.

## Getting Started
You will need an okta account to get started. Then you have to set one the callback functions accordingly. 
[Okta](https://help.okta.com/en/prod/Content/Topics/Access-Gateway/configure-idp-okta.htm)

To run this backend server all you need to do is run with
`dotnet run` This will start the backend server. 


## Usage
To interact directly with the API you can create request with your favorite HTTP Request maker or on the browser.
S
I highly recommend you visit the other github repo and learn to run them both simultaneously.

## License
YourEpic uses the MIT License Format 
