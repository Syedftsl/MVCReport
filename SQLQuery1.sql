use master
create database StudentInfo

use StudentInfo
create table Students
(
	StudentID int primary key identity not null,
	StudentName varchar(20) not null,
	Mobile varchar(15) not null,
	Email varchar(20) not null
) 