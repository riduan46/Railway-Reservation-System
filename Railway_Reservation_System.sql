CREATE DATABASE RailwayReservationSystem

CREATE TABLE MessageList (
  MessageID varchar(30) Primary Key,
  FullName varchar(100) NOT NULL,
  ContactNumber varchar(20) NOT NULL,
  Email varchar(50) NOT NULL,
  Message varchar(300) NOT NULL,
  Status varchar(10) NOT NULL,
  DateCreated datetime NOT NULL,
);

CREATE TABLE TrainList (
  TrainID varchar(30) Primary Key,
  TrainCode varchar(100) NOT NULL,
  TrainName varchar(50) NOT NULL,
  RouteFrom varchar(50) NOT NULL,
  RouteTo varchar(30) NOT NULL,
  DepartureTime time NOT NULL,
  ArrivalTime time NOT NULL,
  TotalSeats numeric (8,2) NOT NULL,
  TrainType varchar(50) NOT NULL,
  FirstClassCapacity numeric(8,2) NOT NULL,
  EconomyCapacity numeric(8,2) NOT NULL,
  DateCreated datetime NOT NULL,
  DateUpadeted datetime NOT NULL,
);

CREATE TABLE Stations (
    StationID varchar(30) PRIMARY KEY,
    StationName VARCHAR(100) NOT NULL,
    Location varchar(50) NOT NULL
);

CREATE TABLE Schedule (
  ScheduleID varchar (30) Primary Key,
  ScheduleCode varchar(100) NOT NULL,
  TrainID varchar(30) NOT NULL,
  StationID varchar(30),
  ScheduleType varchar(10)  NOT NULL,
  DepartureTime time NOT NULL,
  ArrivalTime time NOT NULL,
  FirstClassFare Numeric(8,2) NOT NULL,
  EconomyFare Numeric(8,2) NOT NULL,
  DateCreated datetime NOT NULL,
  DateUpadeted datetime NOT NULL,
  Foreign Key (TrainID) references TrainList,
Foreign Key (StationID) references Stations
);

CREATE TABLE Users (
  UserID varchar (30) Primary Key,
  UserName varchar(50) NOT NULL,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  ContactNumber varchar(20) NOT NULL,
  Email varchar(50) NOT NULL,
  Password varchar(50) NOT NULL,
  Picture varchar(50) NOT NULL,
  LastLogin datetime NOT NULL,
  UserType varchar(10) NOT NULL,
  Status varchar(10) NOT NULL,
  DateAdded datetime NOT NULL,
  DateUpdated datetime NOT NULL
);

CREATE TABLE Reservation (
  ResID varchar(30) Primary Key,
  UserID varchar (30) NOT NULL,
  TrainID varchar(30) NOT NULL,
  SourceStation varchar(100) NOT NULL,
  DestinationStation varchar(100) NOT NULL,
  TravelDate datetime NOT NULL,
  BookingDate datetime NOT NULL,
  SeatName varchar(50) NOT NULL,
  ScheduleID varchar(30) NOT NULL,
  ScheduleDate datetime NOT NULL,
  SeatNumber varchar(10) NOT NULL,
  SeatType varchar(10) NOT NULL ,
  TrainType varchar(50) NOT NULL,
  FareAmount numeric(8,2) NOT NULL,
  DateCreated datetime NOT NULL,
  DateUpadeted datetime NOT NULL,
  Status varchar(10) NOT NULL,
  Foreign Key (ScheduleID) references Schedule,
  Foreign Key (TrainID) references TrainList,
  Foreign Key (UserID) references Users
);

CREATE TABLE Payments (
    PaymentID varchar(30) Primary Key,
    ResID varchar(30) NOT NULL,
    UserID varchar (30) NOT NULL,
    Amount numeric(8, 2) NOT NULL,
    PaymentDate datetime,
    PaymentMethod varchar(50) NOT NULL,
    Status varchar(10) NOT NULL,
    FOREIGN KEY (ResID) REFERENCES Reservation,
    FOREIGN KEY (UserID) REFERENCES Users
);