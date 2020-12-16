--populate categories
insert into [ProjTwo].[Category] (name) values ('Fantasy');
insert into [ProjTwo].[Category] (name) values ('Fiction');
insert into [ProjTwo].[Category] (name) values ('Mystery');
insert into [ProjTwo].[Category] (name) values ('Fan-Fic');

--populate roles
insert into [ProjTwo].[Role] (name) values ('Reader');
insert into [ProjTwo].[Role] (name) values ('Publisher');

--populate users
insert into [ProjTwo].[User] (Name, Role, Email) values ('Daniel Grant', 2, 'daniel.grant@revature.net');
insert into [ProjTwo].[User] (Name, Role, Email) values ('Antonio Mendez', 2, 'antonio.mendez@revature.net');
insert into [ProjTwo].[User] (Name, Role, Email) values ('Alex Soto', 2, 'alex.soto@revature.net');
insert into [ProjTwo].[User] (Name, Role, Email) values ('Gavin Mendez', 1, 'ilove2read@gmail.com');

--Gavin subscribes to all publishers, big fan
insert into [ProjTwo].[Subscription] (WriterID, SubscriberID) values (1,1);
insert into [ProjTwo].[Subscription] (WriterID, SubscriberID) values (1,2);
insert into [ProjTwo].[Subscription] (WriterID, SubscriberID) values (1,3);

--populate an epic
insert into [ProjTwo].[Epic] (Name, writerID) values ('Sample Title', 2);
--give the epic a chapter
insert into [ProjTwo].[Chapter] (Title, EpicID, Text) values ('Chapter 1', 1, 'There once was a story that end in one sentence.')
--assign the category for that epic
insert into [ProjTwo].[EpicCategory] (EpicID, CategoryID) values(1, 1);
--assign rating for it
insert into [ProjTwo].[Rating] (RaterID, EpicID, Rating) values (4, 1, 5);
--give a comment for the epic
insert into [ProjTwo].[Comment] (CommenterID, EpicID, Comment) values (4, 1, 'I love this epic. Its EPIC!')