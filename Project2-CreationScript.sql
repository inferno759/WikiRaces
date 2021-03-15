/* Project 2 creation script 3/14/2020
* Trevor Dunbar, Brandon Faulkenberry, Caleb Owens
*/

CREATE TABLE Users (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Username nvarchar(25) NOT NULL,
	Password nvarchar(25) NOT NULL,
);

CREATE TABLE Races (
	ID int IDENTITY(1,1) PRIMARY KEY,
	AuthorID int FOREIGN KEY REFERENCES Users(ID),
	Title nvarchar(100),
	Type nvarchar(50),
	TimeLimit float,
	StepLimit int,
	StartPage varchar(1000),
	EndPage varchar(1000)
);

CREATE TABLE Leaderboard (
	ID int IDENTITY(1,1) PRIMARY KEY,
	RaceID int FOREIGN KEY REFERENCES Races(ID),
	UserID int FOREIGN KEY REFERENCES Users(ID),
	Score int,
	TimeElapsed float,
	StepsTaken int,
	CompletionDate Datetime
);

CREATE TABLE PathStep (
	ID int IDENTITY(1,1) PRIMARY KEY,
	LeaderboardID int FOREIGN KEY REFERENCES Leaderboard(ID),
	CurrentPage varchar(1000),
	StepNumber int,
	TimeSpent float
);

CREATE TABLE Friends (
	ID int IDENTITY(1,1) PRIMARY KEY,
	UserID int FOREIGN KEY REFERENCES Users(ID),
	FriendID int FOREIGN KEY REFERENCES Users(ID),
);	
