CREATE DATABASE BeautySalon

USE BeautySalon

CREATE TABLE [Skills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE
)

CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50) NOT NULL UNIQUE, 
	[Password] varchar(64) NOT NULL,
	[Salt] varchar(50) NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Phone] varchar(25) NOT NULL,
	[Email] varchar(50) NOT NULL,
	[TypeId] int,
	[EmployeeRequest] bit
)

CREATE TABLE [ServiceGroups] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE
)

CREATE TABLE [Services] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE, 
	[Price] decimal(15, 4) NOT NULL,
	[Time] time NOT NULL,
	[GroupId] int FOREIGN KEY REFERENCES [ServiceGroups]([Id]) NOT NULL
)

CREATE TABLE [Appointments] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Date] datetime NOT NULL,
	[ServiceId] int FOREIGN KEY REFERENCES [Services]([Id]) NOT NULL,
	[CustomerId] int FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
	[EmployeeId] int FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
)

CREATE TABLE [UserSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int,
	[SkillId] int,
	FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	FOREIGN KEY ([SkillId]) REFERENCES [Skills]([Id])
)

CREATE TABLE [ServiceSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[ServiceId] int,
	[SkillId] int,
	FOREIGN KEY ([ServiceId]) REFERENCES [Services]([Id]),
	FOREIGN KEY ([SkillId]) REFERENCES [Skills]([Id])
)