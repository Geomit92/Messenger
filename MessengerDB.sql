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

DROP TABLE Messages;

DROP TABLE Users;


INSERT INTO Users(Username,Password,Role,Deleted) VALUES ('Admin','Admin','Admin',0);
INSERT INTO Users(Username,password,Role,Deleted) VALUES ('Mod','Mod','Mod',0);
INSERT INTO Users(Username,password,Role,Deleted) VALUES ('Friend','Friend','Friend',0);
INSERT INTO Users(Username,password,Role,Deleted) VALUES ('Guest','Guest','Guest',0);

