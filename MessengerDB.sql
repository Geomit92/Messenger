CREATE DATABASE Private_Messenger;

CREATE TABLE Users(
	UsernameID INT IDENTITY (1,1),
	Username NVARCHAR(30) NOT NULL,
	Password NVARCHAR (max)	NOT NULL,
	Role NVARCHAR(15) NOT NULL,
	Deleted bit NOT NULL,
				PRIMARY KEY(UsernameID)	
);


CREATE TABLE Messages(
	MessageID INT IDENTITY(1000,1),
	Date DateTime NOT NULL,
	Sender NVARCHAR(30) NOT NULL,
	Receiver NVARCHAR(30) NOT NULL,
	UserMessage NVARCHAR(max) NOT NULL,
	Deleted bit NOT NULL,
				PRIMARY KEY (MessageID),
				
);


INSERT INTO Users(Username,Password,Role,Deleted) VALUES ('admin','admin','Admin',0);
INSERT INTO Users(Username,password,Role,Deleted) VALUES ('mod','mod','Mod',0);
INSERT INTO Users(Username,password,Role,Deleted) VALUES ('friend','friend','Friend',0);
INSERT INTO Users(Username,password,Role,Deleted) VALUES ('loyal','loyal','Loyal',0);
INSERT INTO Users(Username,password,Role,Deleted) VALUES ('guest','guest','Guest',0);

