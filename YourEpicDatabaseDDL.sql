CREATE SCHEMA ProjTwo;
GO

-- Create User Table
-- DROP TABLE [ProjTwo].[User];
CREATE TABLE [ProjTwo].[User] (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Role INT NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE
);
-- Get entire User Table
SELECT * FROM [ProjTwo].[User];

--|--------------------- Add Foreign Key(s) ----------------------------|-
-- ALTER TABLE [ProjTwo].[User] DROP CONSTRAINT FK_UserRole;
ALTER TABLE [ProjTwo].[User]
ADD CONSTRAINT FK_UserRole
FOREIGN KEY (Role) REFERENCES [ProjTwo].[Role](ID)
ON DELETE CASCADE;
----------------------------------------------------------------------------------------
-- Create Epic Table
-- DROP TABLE [ProjTwo].[Epic]
CREATE TABLE [ProjTwo].[Epic](
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    WriterID INT NOT NULL,
    DateCreated DATETIME DEFAULT GETDATE()
);
 -- GET Entire Epics table
 SELECT * FROM [ProjTwo].[Epic]

--|--------------------- Add Foreign Key(s) ----------------------------|--
-- ALTER TABLE [ProjTwo].[Epic] DROP CONSTRAINT FK_EpicWriterID;
ALTER TABLE [ProjTwo].[Epic]
ADD CONSTRAINT FK_EpicWriterID
FOREIGN KEY (WriterID) REFERENCES [ProjTwo].[User](ID)
ON DELETE CASCADE;

 --------------------------------------------------------------------------------------
-- Create Chapter Table
-- DROP TABLE [ProjTwo].[Chapter]
CREATE TABLE [ProjTwo].[Chapter](
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    EpicID INT NOT NULL,
    DateCreated DATETIME DEFAULT GETDATE(),
    Text NVARCHAR(MAX) NOT NULL
);
 -- GET Entire Epics table
 SELECT * FROM [ProjTwo].[Chapter];

--|--------------------- Add Foreign Key(s) ----------------------------|--
-- ALTER TABLE [ProjTwo].[Chapter] DROP CONSTRAINT FK_ChapterEpicID;
ALTER TABLE [ProjTwo].[Chapter]
ADD CONSTRAINT FK_ChapterEpicID
FOREIGN KEY (EpicID) REFERENCES [ProjTwo].[Epic](ID)
ON DELETE CASCADE;

----------------------------------------------------------------------------------------
-- Create Rating Table
-- DROP TABLE [ProjTwo].[Rating]
CREATE TABLE [ProjTwo].[Rating] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RaterID INT NOT NULL,
    EpicID INT NOT NULL, 
    Rating INT NOT NULL
);

-- Get Entire Rating Table 
SELECT * FROM [ProjTwo].[Rating];

--|--------------------- Add Foreign Key(s) ----------------------------|--
-- ALTER TABLE [ProjTwo].[Rating] DROP CONSTRAINT FK_RatingRaterID;
ALTER TABLE [ProjTwo].[Rating]
ADD CONSTRAINT FK_RatingRaterID
FOREIGN KEY (RaterID) REFERENCES [ProjTwo].[User](ID);

-- ALTER TABLE [ProjTwo].[Rating] DROP CONSTRAINT FK_RatingEpicID;
ALTER TABLE [ProjTwo].[Rating]
ADD CONSTRAINT FK_RatingEpicID
FOREIGN KEY (EpicID) REFERENCES [ProjTwo].[Epic](ID)
ON DELETE CASCADE;
----------------------------------------------------------------------------------------
-- Create Comment Table
-- DROP TABLE [ProjTwo].[Comment]
CREATE TABLE [ProjTwo].[Comment] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CommenterID INT NOT NULL,
    EpicID INT NOT NULL,
    Comment NVARCHAR(300) NOT NULL,
    DateCreated DATETIME DEFAULT GETDATE()
);

-- Get Entire Comment Table 
SELECT * FROM [ProjTwo].[Comment];

--|--------------------- Add Foreign Key(s) ----------------------------|--
-- ALTER TABLE [ProjTwo].[Comment] DROP CONSTRAINT FK_CommentCommenterID;
ALTER TABLE [ProjTwo].[Comment]
ADD CONSTRAINT FK_CommentCommenterID
FOREIGN KEY (CommenterID) REFERENCES [ProjTwo].[User](ID);

-- ALTER TABLE [ProjTwo].[Comment] DROP CONSTRAINT FK_CommentEpicID;
ALTER TABLE [ProjTwo].[Comment]
ADD CONSTRAINT FK_CommentEpicID
FOREIGN KEY (EpicID) REFERENCES [ProjTwo].[Epic](ID)
ON DELETE CASCADE;
----------------------------------------------------------------------------------------
-- Create Subscriptions Table
-- DROP TABLE [ProjTwo].[Subscription]
CREATE TABLE [ProjTwo].[Subscription] (
    WriterID INT NOT NULL,
    SubscriberID INT NOT NULL,
	HasNewContent BIT default 0
);

-- Get Entire Rating Table 
SELECT * FROM [ProjTwo].[Subscription];

--|--------------------- Add Foreign Key(s) ----------------------------|--
-- ALTER TABLE [ProjTwo].[Subscription] DROP CONSTRAINT FK_SubscriptionWriterID;
ALTER TABLE [ProjTwo].[Subscription]
ADD CONSTRAINT FK_SubscriptionWriterID
FOREIGN KEY (WriterID) REFERENCES [ProjTwo].[User](ID);

-- ALTER TABLE [ProjTwo].[Subscription] DROP CONSTRAINT FK_SubscriptionSubscriberID;
ALTER TABLE [ProjTwo].[Subscription]
ADD CONSTRAINT FK_SubscriptionSubscriberID
FOREIGN KEY (SubscriberID) REFERENCES [ProjTwo].[User](ID)
ON DELETE CASCADE;

-- <<<<<<<<>>>>>>>>>> Add Composite Primary Key <<<<<<<<>>>>>>>>>>  --
-- ALTER TABLE [ProjTwo].[Subscription] DROP CONSTRAINT PK_WriterIDSubscriberID
ALTER TABLE [ProjTwo].[Subscription]
ADD CONSTRAINT PK_WriterIDSubscriberID
PRIMARY KEY (WriterID, SubscriberID);

----------------------------------------------------------------------------------------
-- Create Role Table
-- DROP TABLE [ProjTwo].[Role]
CREATE TABLE [ProjTwo].[Role] (
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(40) NOT NULL
);

-- Get Entire Role Table 
SELECT * FROM [ProjTwo].[Role];


----------------------------------------------------------------------------------------
-- Create EpicCategory Table
-- DROP TABLE [ProjTwo].[EpicCategory]
CREATE TABLE [ProjTwo].[EpicCategory] (
    EpicID INT NOT NULL,
    CategoryID INT NOT NULL,
);

-- Get Entire EpicCategory Table 
SELECT * FROM [ProjTwo].[EpicCategory];

--|--------------------- Add Foreign Key(s) ----------------------------|--
-- ALTER TABLE [ProjTwo].[EpicCategory] DROP CONSTRAINT FK_EpicCategoryEpicID;
ALTER TABLE [ProjTwo].[EpicCategory]
ADD CONSTRAINT FK_EpicCategoryEpicID
FOREIGN KEY (EpicID) REFERENCES [ProjTwo].[Epic](ID)
ON DELETE CASCADE;

-- ALTER TABLE [ProjTwo].[EpicCategory] DROP CONSTRAINT FK_EpicCategoryCategoryID;
ALTER TABLE [ProjTwo].[EpicCategory]
ADD CONSTRAINT FK_EpicCategoryCategoryID
FOREIGN KEY (CategoryID) REFERENCES [ProjTwo].[Category](ID)
ON DELETE CASCADE;

-- <<<<<<<<>>>>>>>>>> Add Composite Primary Key <<<<<<<<>>>>>>>>>>  --
-- ALTER TABLE [ProjTwo].[EpicCategory] DROP CONSTRAINT PK_EpicIDCategoryID
ALTER TABLE [ProjTwo].[EpicCategory]
ADD CONSTRAINT PK_EpicIDCategoryID
PRIMARY KEY (EpicID, CategoryID);


----------------------------------------------------------------------------------------
-- Create Category Table
-- DROP TABLE [ProjTwo].[Category]
CREATE TABLE [ProjTwo].[Category] (
    ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    Name VARCHAR(30) NOT NULL
);

-- Get Entire Category Table 
SELECT * FROM [ProjTwo].[Category];

