/* Project 2 creation script 3/14/2020
* Trevor Dunbar, Brandon Faulkenberry, Caleb Owens
*/

/*

DROP TABLE Friends;
DROP TABLE PathStep;
DROP TABLE LeaderboardLines;
DROP TABLE Races;
DROP TABLE Users;

*/

CREATE TABLE Users (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Username nvarchar(25) NOT NULL UNIQUE,
	Password nvarchar(25) NOT NULL,
);

CREATE TABLE Races (
	ID int IDENTITY(1,1) PRIMARY KEY,
	AuthorID int,
	Title nvarchar(100) UNIQUE,
	Type nvarchar(50),
	TimeLimit float,
	StepLimit int,
	StartPage varchar(1000),
	EndPage varchar(1000),
	CONSTRAINT FK_Races_AuthorId FOREIGN KEY (AuthorId) REFERENCES Users
);

CREATE TABLE LeaderboardLines (
	ID int IDENTITY(1,1) PRIMARY KEY,
	RaceID int,
	UserID int,
	Score int,
	TimeElapsed float,
	StepsTaken int,
	CompletionDate Datetime,
	CONSTRAINT FK_Leaderboard_Races FOREIGN KEY (RaceID) REFERENCES Races,
	CONSTRAINT FK_Leaderboard_Users FOREIGN KEY (UserId) REFERENCES Users
);

CREATE TABLE PathStep (
	ID int IDENTITY(1,1) PRIMARY KEY,
	LeaderboardID int,
	CurrentPage varchar(1000),
	StepNumber int,
	TimeSpent float,
	CONSTRAINT FK_PathStep_Leaderboard FOREIGN KEY (LeaderboardID) REFERENCES LeaderboardLines
);

CREATE TABLE Friends (
	ID int IDENTITY(1,1) PRIMARY KEY,
	UserID int,
	FriendID int,
	CONSTRAINT FK_Friends_User FOREIGN KEY (UserID) REFERENCES Users,
	CONSTRAINT FK_Friends_Friend FOREIGN KEY (FriendID) REFERENCES Users
);	

--- some test data

INSERT INTO Users (Username, Password) VALUES ('Trevordunbar', 'Password123!');
INSERT INTO Users (Username, Password) VALUES ('BrandonFaulkenberry', 'BrandonsPassword123!');
INSERT INTO Users (Username, Password) VALUES ('CalebOwens', 'CalebsPassword123!');

INSERT INTO Races (AuthorID, Title, Type, TimeLimit, StepLimit, StartPage, EndPage) VALUES (1, 'Trevors race', 'Timed', 10000, 4, 'https://en.wikipedia.org/wiki/Elvis_Presley', 'https://en.wikipedia.org/wiki/Russia');
INSERT INTO Races (AuthorID, Title, Type, TimeLimit, StepLimit, StartPage, EndPage) VALUES (2, 'Brandons race', 'StepLimit', 10000, 3, 'https://en.wikipedia.org/wiki/Hawaii', 'https://en.wikipedia.org/wiki/Pro_Bowl');
INSERT INTO Races (AuthorID, Title, Type, TimeLimit, StepLimit, StartPage, EndPage) VALUES (3, 'Calebs race', 'Timed', 120, 6, 'https://en.wikipedia.org/wiki/Earth', 'https://en.wikipedia.org/wiki/Extinction');

INSERT INTO LeaderboardLines (RaceID, UserID, Score, TimeElapsed, StepsTaken, CompletionDate) VALUES (1, 2, 100, 500, 2, '20120618 10:34:09 AM');

INSERT INTO PathStep (LeaderboardID, CurrentPage, StepNumber, TimeSpent) VALUES (4, 'https://en.wikipedia.org/wiki/Elvis_Presley', 1, 250);
INSERT INTO PathStep (LeaderboardID, CurrentPage, StepNumber, TimeSpent) VALUES (4, 'https://en.wikipedia.org/wiki/CBS', 2, 250);

INSERT INTO Friends (UserID, FriendID) VALUES (2, 3);
INSERT INTO Friends (UserID, FriendID) VALUES (3, 2);

--- select

SELECT * FROM Friends;
SELECT * FROM LeaderboardLines;
SELECT * FROM PathStep;
SELECT * FROM Races;
SELECT * FROM Users;
