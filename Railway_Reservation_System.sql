CREATE DATABASE Railway_Reservation_System

CREATE TABLE Login(
	Username varchar (30) NOT NULL,
	Password varchar (30) NOT NULL
);

CREATE TABLE TrainList (
  TrainID varchar(30) Primary Key,
  TrainCode varchar(100) NOT NULL,
  TrainName varchar(50) NOT NULL,
  RouteFrom varchar(50) NOT NULL,
  RouteTo varchar(30) NOT NULL,
  DepartureTime time NOT NULL,
  ArrivalTime time NOT NULL,
  TrainType varchar(50) NOT NULL,
  TotalSeats numeric (8,2) NOT NULL,
  TicketFare numeric (8,2) NOT NULL,
  DateCreated datetime NOT NULL,
);


CREATE TABLE Schedule (
  ScheduleID varchar (30) Primary Key,
  ScheduleCode varchar(100) NOT NULL,
  TrainID varchar(30) NOT NULL,
  StationName varchar(30),
  ScheduleType varchar(10)  NOT NULL,
  DepartureTime time NOT NULL,
  ArrivalTime time NOT NULL,
  FirstClassFare Numeric(8,2) NOT NULL,
  EconomyFare Numeric(8,2) NOT NULL,
  DateCreated datetime NOT NULL,
  DateUpadeted datetime NOT NULL,
  Foreign Key (TrainID) references TrainList,
);

CREATE TABLE Passenger (
  PNRID INT Primary Key,
  UserName varchar(50) NOT NULL,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  ContactNumber varchar(20) NOT NULL,
  Gender varchar(30) NOT NULL,
  DoB varchar(30) NOT NULL,
  Email varchar(50) NOT NULL,
  Password varchar(50) NOT NULL,
  Picture image NOT NULL,
  Address varchar(250) NOT NULL,
  PostCode INT NOT NULL,
);

CREATE TABLE Reservation (
  ResID varchar(30) Primary Key,
  PNRID varchar (30) NOT NULL,
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
  Foreign Key (PNRID) references Passenger
);

CREATE TABLE Payments (
    PaymentID varchar(30) Primary Key,
    ResID varchar(30) NOT NULL,
    PNRID varchar (30) NOT NULL,
    Amount numeric(8, 2) NOT NULL,
    PaymentDate datetime,
    PaymentMethod varchar(50) NOT NULL,
    Status varchar(10) NOT NULL,
    FOREIGN KEY (ResID) REFERENCES Reservation,
    FOREIGN KEY (PNRID) REFERENCES Passenger
);

