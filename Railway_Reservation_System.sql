CREATE DATABASE Railway_Reservation_System
CREATE TABLE Login(
	Username varchar (30) NOT NULL,
	Password varchar (30) NOT NULL
);
CREATE TABLE TrainList (
  TrainID INT Primary Key,
  TrainCode varchar(100) NOT NULL,
  TrainName varchar(50) NOT NULL,
  RouteFrom varchar(50) NOT NULL,
  RouteTo varchar(30) NOT NULL,
  DepartureTime time NOT NULL,
  ArrivalTime time NOT NULL,
  TrainType varchar(50) NOT NULL,
  TotalSeats numeric (8,2) NOT NULL,
  TicketFare numeric (8,2) NOT NULL,
);
CREATE TABLE Schedule (
  ScheduleID INT Primary Key,
  ScheduleCode varchar(100) NOT NULL,
  TrainID INT NOT NULL,
  StationName varchar(30),
  ScheduleType varchar(20)  NOT NULL,
  DepartureTime time NOT NULL,
  ArrivalTime time NOT NULL,
  TrainType varchar(20)  NOT NULL,
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
  Picture image,
  Address varchar(250) NOT NULL,
  PostCode INT NOT NULL,
);
CREATE TABLE Reservation (
  ResID INT Primary Key,
  PNRID INT NOT NULL,
  TrainID INT NOT NULL,
  SourceStation varchar(100) NOT NULL,
  DestinationStation varchar(100) NOT NULL,
  TravelDate varchar(30) NOT NULL,
  ScheduleID INT NOT NULL,
  Foreign Key (ScheduleID) references Schedule,
  Foreign Key (TrainID) references TrainList,
  Foreign Key (PNRID) references Passenger
);
CREATE TABLE Payments (
    PaymentID varchar(30) Primary Key,
    ResID INT NOT NULL,
    PNRID INT NOT NULL,
    Amount numeric(8, 2) NOT NULL,
    PaymentMethod varchar(50) NOT NULL,
    FOREIGN KEY (ResID) REFERENCES Reservation,
    FOREIGN KEY (PNRID) REFERENCES Passenger
);

INSERT INTO TrainList (TrainID, TrainCode, TrainName, RouteFrom, RouteTo, DepartureTime, ArrivalTime, TrainType, TotalSeats, TicketFare)
VALUES 
(101, 'EKSP123', 'Suborno Express', 'Dhaka', 'Chattogram', '07:00:00', '13:00:00', 'Intercity', 800, 550.00),
(102, 'EKSP456', 'Sundarban Express', 'Dhaka', 'Khulna', '08:30:00', '17:45:00', 'Intercity', 900, 600.00),
(103, 'EKSP789', 'Parabat Express', 'Sylhet', 'Dhaka', '06:40:00', '13:30:00', 'Intercity', 750, 500.00),
(104, 'EKSP101', 'Rangpur Express', 'Dhaka', 'Rangpur', '09:00:00', '18:30:00', 'Intercity', 850, 700.00);

INSERT INTO Schedule (ScheduleID, ScheduleCode, TrainID, StationName, ScheduleType, DepartureTime, ArrivalTime, TrainType)
VALUES 
(201, 'SCHD001', 101, 'Dhaka', 'Daily', '07:00:00', '07:00:00', 'Intercity'),
(202, 'SCHD002', 103, 'Narsingdi', 'Daily', '08:30:00', '08:35:00', 'Intercity'),
(203, 'SCHD003', 102, 'Brahmanbaria', 'Daily', '10:00:00', '10:05:00', 'Intercity'),
(204, 'SCHD004', 101, 'Feni', 'Daily', '12:00:00', '12:05:00', 'Intercity'),
(205, 'SCHD005', 104, 'Chattogram', 'Daily', '13:00:00', '13:00:00', 'Intercity');

INSERT INTO Passenger (PNRID, UserName, FirstName, LastName, ContactNumber, Gender, DoB, Email, Password, Address, PostCode)
VALUES 
(301, 'rajib123', 'Rajib', 'Hasan', '01711234567', 'Male', '1995-05-10', 'rajib.hasan@gmail.com', 'pass123', 'Mirpur, Dhaka', 1216),
(302, 'tahsin321', 'Tahsin', 'Rahman', '01987654321', 'Male', '1990-09-22', 'tahsin.rahman@yahoo.com', 'secure456', 'GEC, Chattogram', 4000),
(303, 'afrin789', 'Afrin', 'Jahan', '01812340987', 'Female', '1998-02-14', 'afrin.jahan@outlook.com', 'afrin321', 'Banani, Dhaka', 1213),
(304, 'mehedi456', 'Mehedi', 'Kamal', '01655667788', 'Male', '1988-11-30', 'mehedi.kamal@hotmail.com', 'mehpass987', 'Khulna Sadar, Khulna', 9100);

INSERT INTO Reservation (ResID, PNRID, TrainID, SourceStation, DestinationStation, TravelDate, ScheduleID)
VALUES 
(401, 301, 101, 'Dhaka', 'Chattogram', '2025-03-15', 201),
(402, 302, 101, 'Narsingdi', 'Chattogram', '2025-03-16', 202),
(403, 303, 103, 'Sylhet', 'Dhaka', '2025-04-10', 203),
(404, 304, 102, 'Dhaka', 'Khulna', '2025-04-12', 204);


INSERT INTO Payments (PaymentID, ResID, PNRID, Amount, PaymentMethod)
VALUES
('BK202501', 401, 301, 550.00, 'bKash'),
('NG202502', 402, 302, 600.00, 'Nagad'),
('RK202503', 403, 303, 500.00, 'Rocket'),
('CC202504', 404, 304, 700.00, 'Credit Card');
