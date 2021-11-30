create database TMSDB
use TMSDB

create table TM_VEHICLEDETAILS
(
VEH_ID int primary key identity(10000,1),
VEH_TYPE varchar(20) not null,
ENGINE_NO varchar(20) unique,
MODEL_NO varchar(20) not null,
VEH_NAME varchar(20) not null,
VEH_COLOR varchar(10),
MANUFACTURER_NAME varchar(15) not null,
DATE_OF_MANUFACTURE date not null,
STATUS varchar(10),
NO_OF_CYCLINDERS int,	
CUIBIC_CAPACITY int,	
FUEL_USED varchar(10)	
)

create table TM_OWNERDETAILS
(
OWNER_ID int primary key identity(1000,1),
FNAME varchar(20) not null,
LNAME varchar(20) not null,
DATEOFBIRTH	date not null,
LANDLINE_NO	bigint,	
MOBILE_NO bigint,	
GENDER varchar(10) not null,
TEMP_ADDR varchar(50),	
PERM_ADDR varchar(50) not null,
PINCODE	int not null,
OCCUPATION varchar(15),	
PANCARD_NO varchar(20) not null,
ADD_PROOF_NAME varchar(20) not null
)

create table TM_REGDETAILS
(
APP_NO varchar(10) primary key,
VEH_NO varchar(10) unique,
VEH_ID int references TM_VEHICLEDETAILS(VEH_ID),
OWNER_ID int references TM_OWNERDETAILS(OWNER_ID),
OLD_OWNER_ID int references TM_OWNERDETAILS(OWNER_ID),
DATE_OF_PURCHASE datetime not null,
DISTRUBUTER_NAME varchar(20) not null
)

create table TM_OFFENCE
(
OFFENCE_ID int primary key identity(100,5),
OFFENCE_TYPE varchar(50) not null,
VEH_TYPE varchar(50) not null,
PENALTY int not null
)

create table OFFENCE_DETAILS
(
OFFENCE_NO int primary key identity(1,1) not null,
VEH_NO varchar(10)  references TM_REGDETAILS(VEH_NO),
TIME datetime not null,
PLACE varchar(15) not null,
OFFENCE_ID int references TM_OFFENCE(OFFENCE_ID),
REPORTED_BY	varchar(20) not null,
STATUS varchar(10) check(STATUS in('PAID','NOT PAID'))
)

create table TM_USERMASTER
(
USERNAME varchar(15) primary key,
PASSWORD varchar(15) not null,
ROLENAME varchar(15) not null
)