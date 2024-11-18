create database assigment2;
create table userT2
(
UserId  int identity(1,1) primary key,
UName nvarchar(40) ,
UPassword nvarchar (40),
email nvarchar (40) unique ,
urole nvarchar (40)
);

INSERT INTO userT2(UName,UPassword,email,urole)
VALUES 
('loka', 'password123', 'HAEEL@gmail.com','employee'),
('malak', 'password1', 'Malak@gmail.com','employee'),
('abd', 'password12', 'S3ODY@gmail.com','employee'),
('HIMA', 'ibrahim', 'HIMA@gmail.com','employee');
create table task2
(
TaskId  int primary key  identity(1,1) ,
title nvarchar (40),
Tdescription nvarchar (40),
TStatus nvarchar (40),
Duedate int,
USId int,
FOREIGN KEY (USId) REFERENCES userT2 (UserId )
);
INSERT INTO task2(title,Tdescription ,TStatus,Duedate,USId)
VALUES 
('software', 'login', 'pending','emplyee',2024,1),
('backend', 'signup', 'pending','emplyee',2024,2),
('frontend', 'desktop', 'in progress','emplyee',2024,3),
('math', 'app', 'completed','emplyee',2024,4);




