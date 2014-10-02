/* Create Database */
CREATE DATABASE CustomerDB
GO

/* Use Database */
use CustomerDB
Go

/* Create Table Customers  */

CREATE TABLE tbl_Customers
(
CUSTOMER_ID				int	IDENTITY	(1,1)	PRIMARY KEY,
COMPANYNAME				varchar			(30)		NOT NULL,
ADDRESS1				varchar			(30)		NOT NULL,
POSTALCODE1				varchar			(7)			NOT NULL,
RESIDENCE1				varchar			(30)		NOT NULL,
ADDRESS2				varchar			(30),
POSTALCODE2				varchar			(7)	,
RESIDENCE2				varchar			(30),
CONTACTPERSON			varchar			(30)		NOT NULL,
INITIALS				Varchar			(10)		NOT NULL,
PHONE_NR1				int							NOT NULL,
PHONE_NR2				int							NOT NULL,
FAXNUMBER				int							NOT NULL,
EMAIL					varchar			(60)		NOT NULL,
DATE_OF_ACTION			date				,
LAST_CONTACT_DATE		date				,
NEXT_ACTION				date				,
OFFER_NUMBERS			int					,
OFFER_STAT				bit					,
PROSPECT				bit					,
SALE_PERC				decimal				,
CRED_WORTH				bit					,
BALANCE					int					,
LIMIT					money				,
LEDGER_ID				int					,
BTW_CODE				decimal				,
BKR						bit					,
ACC_ID					int					,
HARDWARE				varchar			(30),
SOFTWARE				varchar			(30),
OPEN_PROJ				Varchar			(30),
MAINT_CONTR				bit					,
INT_CONTACT				varchar			(30)
);

/* Create Table tbl_Appointments */

CREATE TABLE tbl_Appointments
(
	APPOINTMENT_ID		int identity(1,1) PRIMARY KEY,
	CUSTOMER_ID			int NOT NULL,
	APPOIN_DATE			date NOT NULL,
	SUBJECT				varchar(30) NOT NULL
)


/*	Create Table Invoices	*/

CREATE TABLE tbl_Invoices
(
	INVOICE_ID			INT IDENTITY(1,1) PRIMARY KEY,
	PROJECT_ID			INT NOT NULL,
	INVOICE_VALUE		Money NOT NULL,
	INVOICE_SEND		DATE NOT NULL,
	INVOICE_END_DATE	DATE NOT NULL
)


/*	Create Table tbl_Projects	*/

CREATE TABLE tbl_Projects
(
	ProjectID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerID INT NOT NULL,
	Name varchar(30) NOT NULL,
	Deadline DATE NOT NULL,
	Subject varchar(30) NOT NULL
)


/*	Create Table tbl_Users	*/

CREATE TABLE tbl_Users
(
	USER_ID INT IDENTITY(1,1) PRIMARY KEY,
	USER_NAME VARCHAR(30) NOT NULL,
	PASSWORD VARCHAR (30) NOT NULL,
	DEPARTMENT VARCHAR(30) NOT NULL
)







/* Test Query Insert into */
/*Insert into tbl_Customers (CUSTOMER_ID, COMPANYNAME, ADDRESS1, POSTALCODE1, RESIDENCE1, ADDRESS2, POSTALCODE2, RESIDENCE2, CONTACTPERSON, INITIALS, PHONE_NR1, PHONE_NR2, FAXNUMBER, EMAIL, DATE_OF_ACTION, LAST_CONTACT_DATE, NEXT_ACTION, OFFER_NUMBERS, OFFER_STAT, PROSPECT, SALE_PERC, CRED_WORTH, BALANCE, LIMIT, LEDGER_ID, BTW_CODE, BKR, ACC_ID, HARDWARE, SOFTWARE, OPEN_PROJ, MAINT_CONTR, INT_CONTACT)
Values ('', '', '');
*/
