CREATE DATABASE BeautySalon
GO

USE BeautySalon
GO

CREATE TABLE [UserTypes] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE
)

CREATE TABLE [Skills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE
)

/* One to many with UserTypes */
/* Many to many with Skills */
CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50) NOT NULL UNIQUE, 
	[Password] varchar(64) NOT NULL,
	[Salt] varchar(50) NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Phone] varchar(25) NOT NULL,
	[Email] varchar(50) NOT NULL,
	[TypeId] int FOREIGN KEY REFERENCES [UserTypes]([Id]) NOT NULL
)

/* Many to many with Skills */
CREATE TABLE [Services] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE, 
	[Price] decimal(15, 4) NOT NULL,
	[Time] time NOT NULL
)

/* One to many with Services and Users */
CREATE TABLE [Appointments] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Date] date NOT NULL,
	[ServiceId] int FOREIGN KEY REFERENCES [Services]([Id]) NOT NULL,
	[CustomerId] int FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
	[EmployeeId] int FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
)

/* Cross table of Users and Skills */
CREATE TABLE [UsersSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int,
	[SkillId] int,
	FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	FOREIGN KEY ([SkillId]) REFERENCES [Skills]([Id])
)

/* Cross table of Services and Skills */
CREATE TABLE [ServicesSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[ServiceId] int,
	[SkillId] int,
	FOREIGN KEY ([ServiceId]) REFERENCES [Services]([Id]),
	FOREIGN KEY ([SkillId]) REFERENCES [Skills]([Id])
)