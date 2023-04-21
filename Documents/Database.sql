CREATE DATABASE SalonManagement
USE SalonManagement

CREATE TABLE Skills(
	Id INT PRIMARY KEY	IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL	
);

CREATE TABLE Employees(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(32) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	[Description] NVARCHAR(250) NOT NULL,
	SkillId INT FOREIGN KEY REFERENCES Skills(Id)
);

CREATE TABLE [Services](
	Id INT PRIMARY KEY	IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Price INT NOT NULL
);

CREATE TABLE Appointments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	ServiceId INT FOREIGN KEY REFERENCES [Services](Id),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
);

CREATE TABLE Customers(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(64) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL
);

CREATE TABLE CustomersAppointments(
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	AppointmentId INT FOREIGN KEY REFERENCES Appointments(Id),
	PRIMARY KEY(CustomerId, AppointmentId)
);