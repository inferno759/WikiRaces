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
