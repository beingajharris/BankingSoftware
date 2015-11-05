USE master;

-- Drop database
IF DB_ID('Banking System') IS NOT NULL DROP DATABASE [Banking System];

-- If database could not be created due to open connections, abort
IF @@ERROR = 3702 
   RAISERROR('Database cannot be dropped because there are still open connections.', 127, 127) WITH NOWAIT, LOG;

--DROP DATABASE [Banking System];
CREATE DATABASE [Banking System];

USE [Banking System]
GO

CREATE SCHEMA Account AUTHORIZATION dbo;
GO
CREATE SCHEMA HumanResources AUTHORIZATION dbo;
GO
CREATE SCHEMA Person AUTHORIZATION dbo;
GO
CREATE SCHEMA Customer AUTHORIZATION dbo;
GO
CREATE SCHEMA Users AUTHORIZATION dbo;
GO

--Employees Tables
--DROP TABLE [HumanResources].[Employees]
CREATE TABLE [HumanResources].[Employees]
(
emplNumber		INT IDENTITY(12140000,1)NOT NULL		PRIMARY KEY,
firstname		varchar(15)				NOT NULL,
surname			varchar(15)				NOT NULL,
lastname		varchar(15)				NULL,
DOB				date					NOT NULL,
identitynumber	nvarchar(13)			NOT NULL,
gender			varchar(6)				NOT NULL,
position		varchar(30)				NOT NULL,
picture			image					NULL
);

--Employees user accounts
--DROP TABLE [Users].[Users] 
CREATE TABLE [Users].[Users]
(
userID			INT IDENTITY(2000,1)	NOT NULL		PRIMARY KEY,
userName		nvarchar(15)			NOT NULL,
userPwd			nvarchar(15)			NOT NULL,
pwdAttempt		int						NOT NULL,
lock			bit						NULL,
userType		varchar(15)				NOT NULL,
errorMsg		nvarchar(150)			NOT NULL,
empNumber		INT						NOT NULL


CONSTRAINT FK_users_empNumber FOREIGN KEY(empNumber)
REFERENCES [HumanResources].[Employees](emplNumber) ON DELETE CASCADE
);
--DROP TABLE [Users].[Blocked]
CREATE TABLE [Users].[Blocked]
(
userID			int						NOT NULL,
active			bit						NOT NULL,
reason			nvarchar(250)			NOT NULL
);
--DROP TABLE [Users].[Recovery]
CREATE TABLE [Users].[Recovery]
(
userID			int						NOT NULL,
securityQst		nvarchar(30)			NOT NULL,
securityAnswr	nvarchar(30)			NOT NULL,
);

--DROP TABLE [Users].[Type]
CREATE TABLE [Users].[Type]
(
usertypeID		INT IDENTITY(9000,1)	NOT NULL		PRIMARY KEY,
userType		nvarchar(30)			NOT NULL,
[Description]	nvarchar(250)			NOT NULL,
);

--DROP TABLE [Users].[Allowance]
CREATE TABLE [Users].[Allowance]
(
usertypeID		int						NOT NULL,

);

--DROP TABLE [HumanResources].[EmployeeContact]
CREATE TABLE [HumanResources].[EmployeeContact]
(
empNumber		INT						NOT NULL,
cellnumber		nvarchar(10)			NOT NULL, 
email			nvarchar(25)			NOT NULL,
[address1]		nvarchar(40)			NOT NULL,
[address2]		nvarchar(40)			NOT NULL

CONSTRAINT FK_empContact_empNumber FOREIGN KEY(empNumber)
REFERENCES [HumanResources].[Employees](emplNumber) ON DELETE CASCADE
);


INSERT INTO [HumanResources].[Employees] 
VALUES('Surprise','Mashaba','Mac donald','1995/01/15','9501156158089','Male','Teller',NULL),
	  ('Maria','Mphahlele',NULL,'1978/06/12','7806120874557','Female','Teller',NULL),
	  ('Betty','Moloto',NULL,'1976/07/11','7607110874558','Female','Teller',NULL),
	  ('John','Ngwenya',NULL,'1977/06/22','7706220874455','Male','Teller',NULL),
	  ('fanafana','Ceko','kevin','1971/11/12','7111208617455','Female','Manager',NULL),
	  ('Julia','Mashaba','Masesana','1978/11/26','7811260158089','Female','System Supervisor',NULL),
	  ('Sthembiso','Mashaba','Abby','1990/04/07','9004076158089','Male','Sales Co-ordinator',NULL)
	
INSERT INTO [Users].[Users] 
VALUES('sur376','vuk@1004',3,'False','Teller','okay',(SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '9501156158089')),
	  ('admin','12345',3,'False','Teller','okay',(SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7806120874557')),
	  ('bty874','ytb$7778',3,'False','Teller','okay',(SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7607110874558')),
	  ('joh209','noh@1024',3,'False','Teller','okay',(SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7706220874455')),
	  ('fnf','kvn@cekp21',3,'False','Administrator','okay',(SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7111208617455')),
	  ('jul56','mas@2611',3,'False','Administrator','okay',(SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7811260158089')),
	  ('mbizo12','aby#989',3,'False','Administrator','okay',(SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '9004076158089'));
 

INSERT INTO [HumanResources].[EmployeeContact] 
VALUES((SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '9501156158089'),'0718380291','surprise376@gmail.com','private bag X 11007 Namakgale 1391','1506 HOME 2000 ZONE C Namakgale 1391'),
	  ((SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7806120874557'),'0763297722','maria296@yahoo.com','private bag X 11007 Namakgale 1391','78 ZONE B Namakgale 1391'),
	  ((SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7607110874558'),'0784517895','betty874@gmail.com','private bag X 11007 Namakgale 1391','159 ZONE B Namakgale 1391'),
	  ((SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7706220874455'),'0637814571','john209@gmail.com','private bag X 11007 Namakgale 1391','5 ZONE D Namakgale 1391'),
	  ((SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7111208617455'),'0714759812','kevin@yahoo.com','private bag X 11007 Namakgale 1391','160 ZONE A Namakgale 1391'),
	  ((SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '7811260158089'),'0787254189','julia56@gmail.com','private bag X 11007 Namakgale 1391','1506 HOME 2000 ZONE C Namakgale 1391'),
	  ((SELECT emplNumber FROM [HumanResources].[Employees] WHERE identitynumber = '9004076158089'),'0749963256','mbizo12@gmail.com','private bag X 11007 Namakgale 1391','1506 HOME 2000 ZONE C Namakgale 1391');

SELECT * FROM [HumanResources].[Employees]
SELECT * FROM [HumanResources].[EmployeeContact]
SELECT * FROM [Users].[Users]
UPDATE [Users].[Users] SET lock='False',errorMsg ='CBY'
WHERE userID = 2000

SELECT firstname AS First_Name,surname AS Surname 
			FROM [HumanResources].[Employees] 
			WHERE emplNumber =(SELECT empNumber FROM [Users].[Users] WHERE userName = 'sur376' AND userPwd = 'vuk@1004')

SELECT userName,userPwd,lock,firstname
			FROM [Users].[Users],[HumanResources].[Employees]
			WHERE userName = 'sur376' AND userPwd = 'vuk@1004' AND emplNumber = '12140000'

--------------------------------------------------------------------------------------------------------------------------------------------------
--Customers Tables--
--------------------------------------------------------------------------------------------------------------------------------------------------
--DROP TABLE TEST
CREATE TABLE TEST
(
name		nvarchar(30) NOT NULL,
picture		image		 NOT NULL,
pic1		image		 NOT NULL,
);

select * from TEST 


--DROP TABLE [Customer].[Customers] 
CREATE TABLE [Customer].[Customers]
(
CustomerID		int IDENTITY(2000000000,1)	NOT NULL		PRIMARY KEY,
firstName		varchar(15)					NOT NULL,
lastName		varchar(15)					NULL,
surname			varchar(15)					NOT NULL,
initials		varchar(10)					NOT NULL,
title			varchar(5)					NOT NULL,
accountHolder	varchar(30)					NOT NULL,
DOB				date						NOT NULL,
identityNumber	nvarchar(13)				NOT NULL,
gender			varchar(6)					NOT NULL,
);



  --select * from Customer.Customers 
  --select * from Customer.Account

--DROP TABLE [Customer].[Images] 
CREATE TABLE [Customer].[Images]
(
CustIDImages	int							NOT NULL,
picture			image						NOT NULL,
idCopy			image						NOT NULL,
Residence		image						NOT NULL,
SuretyIDcopy	image						NULL,
ConsernForm		image						NULL,
dateCreated		date						NOT NULL,
DateModified	date						NOT NULL

CONSTRAINT FK_images_CustomerID FOREIGN KEY(CustIDImages)
REFERENCES [Customer].[customers](CustomerID) ON DELETE CASCADE
);

--INSERT INTO Customer.Images 
--VALUES
--((SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '5107080561085'),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\untitled.png',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\ID.jpg',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\SQL.jpg',single_blob) as [Image]),
--NULL,NULL,'2015/4/10','2015/4/20');

--DROP TABLE [Customer].[ThumbPrints] 
CREATE TABLE [Customer].[ThumbPrints]
(
CustIDThumb		int							NOT NULL,
ThumbPrint		image						NULL
CONSTRAINT FK_ThumbPrints_CustomerID FOREIGN KEY(CustIDThumb)
REFERENCES [Customer].[customers](CustomerID) ON DELETE CASCADE
);
--DROP TABLE [Customer].[LeftThumb] 
CREATE TABLE [Customer].[LeftThumb]
(
CustIDLThumb	int							NOT NULL,
Thumb1			image						NOT NULL,
Thumb2			image						NOT NULL,
Thumb3			image						NOT NULL,
Thumb4			image						NOT NULL,
Thumb5			image						NOT NULL

CONSTRAINT FK_LeftThumb_CustomerID FOREIGN KEY(CustIDLThumb)
REFERENCES [Customer].[customers](CustomerID) ON DELETE CASCADE
);


--DROP TABLE [Customer].[RightThumb] 
CREATE TABLE [Customer].[RightThumb]
(
CustIDRThumb	int							NOT NULL,
Thumb1			image						NOT NULL,
Thumb2			image						NOT NULL,
Thumb3			image						NOT NULL,
Thumb4			image						NOT NULL,
Thumb5			image						NOT NULL

CONSTRAINT FK_RightThumb_CustomerID FOREIGN KEY(CustIDRThumb)
REFERENCES [Customer].[customers](CustomerID) ON DELETE CASCADE
);

--DROP TABLE [Customer].[Account] 
CREATE TABLE [Customer].[Account]
(
accNumber		int	IDENTITY(1000000000,1)	NOT NULL		PRIMARY KEY,
CustIDAcc		int							NOT NULL,
accType			varchar(15)					NOT NULL,
pin				int							NOT NULL,
pinAtempt		int							NOT NULL,
available		money						NOT NULL,
balance			money						NOT NULL,
accState		varchar(10)					NOT NULL,
dateOpened		datetime					NOT NULL,
expires			date						NOT NULL

CONSTRAINT FK_customertAccount_CustomerID FOREIGN KEY(CustIDAcc)
REFERENCES [Customer].[customers](CustomerID) ON DELETE CASCADE
);

UPDATE [Customer].[Account] SET available = 0.00,balance= 0.00 WHERE accNumber = 1000000001
UPDATE [Customer].[Account] SET available = 0.00,balance= 0.00 WHERE accNumber = 1000000000

--DROP TABLE [Customer].[Contact] 
CREATE TABLE [Customer].[Contact]
(
CustIDConact	int							NOT NULL,
cellNumber		nvarchar(10)				NOT NULL,
email			nvarchar(25)				NULL,
[address1]		nvarchar(40)				NOT NULL,
[address2]		nvarchar(40)				NOT NULL

CONSTRAINT FK_customerContact_CustomerID FOREIGN KEY(CustIDConact)
REFERENCES [Customer].[customers](CustomerID) ON DELETE CASCADE

--CONSTRAINT FK_custContact_accNumber FOREIGN KEY(accNumber)
--REFERENCES costomers(accNumber) ON DELETE CASCADE
);

select * from [Customer].[Contact]

--DROP TABLE [Customer].[AccountTnC] 
CREATE TABLE [Customer].[AccountTnC]
(
CustIDAccTnC	int							NOT NULL,
Accepted		bit							NOT NULL,
[Signature]		image						NULL,
ThumbPrint		image						NULL

CONSTRAINT FK_AccountTnC_CustomerID FOREIGN KEY(CustIDAccTnC)
REFERENCES [Customer].[customers](CustomerID) ON DELETE CASCADE
);


DROP TABLE [Customer].[Transactions] 
CREATE TABLE [Customer].[Transactions]
(
transID			INT IDENTITY(1000,1)		NOT NULL		PRIMARY KEY,
accNmbTrans		INT							NOT NULL,
postingDate		datetime					NOT NULL,
transDate		datetime					NOT NULL,
tranDescription	nvarchar(50)					NOT NULL,
fundsIn			money						NOT NULL,
fundsOut		money						NOT NULL,
available		money						NOT NULL,
balance			money						NOT NULL

CONSTRAINT FK_custTransactions_accNmbTrans FOREIGN KEY(accNmbTrans)
REFERENCES [Customer].[Account](accNumber) ON DELETE CASCADE
);

SELECT * FROM [Customer].[Transactions]

--DROP TABLE [Account].[DailyLimit]
CREATE TABLE [Account].[DailyLimit]
(
accNmbDaily		int						NOT NULL			PRIMARY KEY,
amount			money					NOT NULL,
TempAmount		smallmoney				NULL,
period			nvarchar(10)			NOT NULL,
[From]			Date					NULL,
[To]			Date					NULL

CONSTRAINT FK_DailyLimit_accNmbDaily FOREIGN KEY(accNmbDaily)
REFERENCES [Customer].[Account](accNumber) ON DELETE CASCADE
);


--DROP TABLE [Account].[Freezing]
CREATE TABLE [Account].[Freezing]
(
accNmbState		int						NOT NULL,
reason			nvarchar(200)			NULL,
DateFreeze		date					NOT NULL

CONSTRAINT FK_State_accNmbState FOREIGN KEY(accNmbState)
REFERENCES [Customer].[Account](accNumber) ON DELETE CASCADE
);

--DROP TABLE [Account].[StopOrder]
CREATE TABLE [Account].[StopOrder]
(
accNmr			int						NOT NULL,
accNmbStopOrder	int						NOT NULL,
accountHolder	varchar(20)				NOT NULL,
amount			money					NOT NULL,
transactionDate	date					NOT NULL,
dateAdded		date					NOT NULL
);
--select * from Account.Freezing
 
--		UPDATE Account.DailyLimit SET amount = 5000, period = 'Days', [From] = '2015/04/16', [To] = '2015/04/16' 
--		WHERE accNmbDaily = '1000000002' 

--		UPDATE Account.DailyLimit SET [TO] = (SELECT DATEADD(DAY, 1,[TO]) FROM Account.DailyLimit WHERE accNmbDaily = '1000000000')
--		WHERE accNmbDaily = '1000000002' 

--		SELECT * FROM Account.DailyLimit

		--SELECT OrderDate, DATEADD(year,1,OrderDate) AS OneMoreYear,
		--DATEADD(month,1,OrderDate) AS OneMoreMonth,
		--DATEADD(day,-1,OrderDate) AS OneLessDay
		--FROM Sales.SalesOrderHeader
		--WHERE SalesOrderID in (43659,43714,60621);

--INSERT INTO Account.DailyLimit 
--VALUES
--((SELECT accNumber FROM Customer.Account WHERE CustIDAcc =(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089') AND dateOpened = '2015/04/14'),
--2000,NULL,'Forever',NULL,NULL),
--((SELECT accNumber FROM Customer.Account WHERE CustIDAcc =(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089') AND dateOpened = '2014/04/02'),
--2000,NULL,'Forever',NULL,NULL),
--((SELECT accNumber FROM Customer.Account WHERE CustIDAcc =(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '5107080561085') AND dateOpened = '2015/04/10'),
--2000,NULL,'Forever',NULL,NULL);

--SELECT * FROM Account.DailyLimit
--SELECT * FROM Customer.Account   


--DROP TABLE [Account].[Type] 
CREATE TABLE [Account].[Type]
(
AccTypeID		int IDENTITY(2000,1)		NOT NULL		PRIMARY KEY,
AccountType		nvarchar(30)				NOT NULL,
[Description]	text						NOT NULL,
OpeningBal		money						NOT NULL,
MinimumBal		money						NOT NULL
);

--select * from Account.Type 
INSERT INTO [Account].[Type] 
VALUES('Checking account',
' A checking account offers easy access to your money for your daily transactional needs and helps keep your cash secure. Customers can use a debit card or checks to make purchases or pay bills. Accounts may have different options or packages to help waive certain monthly service fees. To determine the most economical choice, compare the benefits of different checking packages with the services you actually need.',
120,60),
('Savings account','A savings account allows you to accumulate interest on funds you’ve saved for future needs. Interest rates can be compounded on a daily, weekly, monthly, or annual basis. Savings accounts vary by monthly service fees, interest rates, method used to calculate interest, and minimum opening deposit. Understanding the account’s terms and benefits will allow for a more informed decision on the account best suited for your needs.',
50,28),
('Certificate of Deposit (CD)',
'Certificates of deposit, or CDs, allow you to invest your money at a set interest rate for a pre-set period of time. CDs often have higher interest rates than traditional savings accounts because the money you deposit is tied up for the life of the certificate – which can range from a few months to several years. Be sure you do not need to draw on those funds before you open a CD, as early withdrawals may have financial penalties.',
200,100),
('Money market account','Money market accounts are similar to savings accounts, but they require you to maintain a higher balance to avoid a monthly fee. Where savings accounts usually have a fixed interest rate, these accounts have rates that vary regularly based on money markets. Money market accounts can have tiered interest rates, providing more favorable rates based on higher balances. Some money market accounts also allow you to write checks against your funds, but on a more limited basis.',
350,170);
--('Individual Retirement Accounts (IRAs)','IRAs, or individual retirement accounts, allow you to save independently for your retirement. These plans are useful if your employer doesn’t offer retirement benefits or you want to save more than your employer-sponsored plan allows. These accounts come in two types: the traditional IRA and Roth IRA. The Roth IRA is popular because the funds can be withdrawn tax-free in many situations. Others prefer traditional IRAs because these contributions are tax-deductible. Both accounts have contribution limits and other requirements you may need to discuss with your tax advisor before choosing your account. Once you understand the types of accounts most banks offer, you can begin to determine which option might be right for you.',
--500,200);

--DROP TABLE [Account].[Fees]
CREATE TABLE [Account].[Fees]
(
feeID			int IDENTITY(200,1) 		NOT NULL			PRIMARY KEY,
fee				nvarchar(35)				NOT NULL,
amount			money						NOT NULL
);

INSERT INTO Account.Fees
VALUES('Deposite',5.50),
('Transfer',2.78),
('Withdrawal',7.91);

SELECT * FROM Account.Fees 

--DROP TABLE [Customer].[MobileBanking] 
CREATE TABLE [Customer].[MobileBanking]
(
accNmrMobBank	INT							NOT NULL			PRIMARY KEY,
EmpNumber		Int							NOT NULL,
AccessPin		int							NOT NULL,
dateActivated	date						NOT NULL,
dateModified	date						NOT NULL

CONSTRAINT FK_mobileBanking_accNumber FOREIGN KEY(accNmrMobBank)
REFERENCES [Customer].[Account](accNumber) ON DELETE CASCADE
);

--DROP TABLE [Customer].[MobileBankingTnC] 
CREATE TABLE [Customer].[MobileBankingTnC]
(
accNmrMobBank	INT							NOT NULL,
Accepted		bit							NOT NULL,
[date]			date						NOT NULL,
[Signature]		image						NULL,
ThumbPrint		image						NULL
);
--INSERT INTO Customer.Images 
--VALUES(
--(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089'),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\untitled.png',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\ID.jpg',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\SQL.jpg',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\c-sharp.jpg',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Pictures\sponge.png',single_blob) as [Image]),
--'2014/04/02','2015/05/20');

--select * from Customer.MobileBanking 

--DROP TABLE [Customer].[RemoteBanking] 
CREATE TABLE [Customer].[RemoteBanking]
(
RemoteBankID	int IDENTITY(5000,1)		NOT NULL		PRIMARY KEY,
accNmrRemote	INT							NOT NULL,
EmpNumber		Int							NOT NULL,
AccessPin		int							NOT NULL,
dateActivated	date						NOT NULL
);

--DROP TABLE [Customer].[RemoteBankingTnC] 
CREATE TABLE [Customer].[RemoteBankingTnC]
(
RemoteBankID	int							NOT NULL,
Accepted		bit							NOT NULL,
[Signature]		image						NULL,
ThumbPrint		image						NULL
);

UPDATE Customer.Account SET available = 00.0, balance = 00.00 WHERE accNumber = '1000000003'

select * from Customer .Customers 
select * from Customer.Account 
select * from Customer.Transactions 
select * from dbo.ErrorLog
select * from Customer.Contact 
select * from Customer.AccountTnC
select * from Customer.Images 
select * from Account.DailyLimit
select * from Customer.MobileBanking 
	
--INSERT INTO Customer.Customers 
--VALUES('Surprise','Mac Dee','Mashaba','1995/01/15','9501156158089','Male');


--INSERT INTO Customer.ThumbPrints
--VALUES(
--(SELECT CustomerID  FROM Customer.Customers WHERE identityNumber = '9501156158089'),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Left\6.JPG',single_blob) as [Image]));

--INSERT INTO Customer.LeftThumb 
--VALUES(
--(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089'),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Right\1.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Right\2.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Right\3.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Right\4.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Right\5.JPG',single_blob) as [Image]));

--INSERT INTO Customer.LeftThumb 
--VALUES(
--(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089'),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Left\1.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Left\2.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Left\3.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Left\4.JPG',single_blob) as [Image]),
--(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Left\6.JPG',single_blob) as [Image]));

--INSERT INTO Customer.Account 
--VALUES(
--(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089'),'Savings',1506,3,50,102,'Active','2015/04/14','2020/04/14');
--select * from Customer.Customers 
--INSERT INTO Customer.Contact
--VALUES(
--(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089'),'0718380291','surprise376@gmail.com','private bag X 11007 Namakgale 1391','1506 HOME 2000 ZONE C Namakgale 1391');


--INSERT INTO Customer.AccountTnC
--VALUES(
--(SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089'),'True',NULL,(select * from openrowset (bulk N'C:\Users\SURPRISEE\Desktop\MCSD\Portfolio\JMR Software\Banking Management System\Application\fingers\Right\5.JPG',single_blob) as [Image]));

--INSERT INTO Customer.Transactions 
--VALUES(
--(SELECT accNumber FROM Customer.Account WHERE CustIDAcc = (SELECT CustomerID FROM Customer.Customers WHERE identityNumber = '9501156158089')),
--'Money In +','2014/04/15','Savings',150);

--SELECT * FROM Customer.Account 
---------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
--Loan Tables
--DROP TABLE loan 
CREATE TABLE loan
(
loanID INT IDENTITY NOT NULL PRIMARY KEY,
accNumber INT NOT NULL,
dateofLoan date NOT NULL,
repayDate date NOT NULL,
interestRate nvarchar(5) NOT NULL,
loanAmount money NOT NULL,
period nvarchar(10) NOT NULL,
amountPM money NOT NULL,
totalAmount money NOT NULL,
balance money NOT NULL
);

--DROP TABLE loanInfo 
CREATE TABLE loanInfo
(
loanID INT NOT NULL,
salary money NOT NULL,
otherIncome money NOT NULL,
deductions money NOT NULL,
tax money NOT NULL,
food money NOT NULL,
cloths money NOT NULL,
accomodation money NOT NULL,
electricity money NOT NULL,
water money NOT NULL,
schoolFees money NOT NULL,
others money NULL

CONSTRAINT FK_loanInfo_loanID FOREIGN KEY(loanID)
REFERENCES loan(loanID) ON DELETE CASCADE

);

--DROP TABLE loanSet 
CREATE TABLE loanSet
(
loanSetID INT IDENTITY NOT NULL PRIMARY KEY,
intRate nvarchar(15) NOT NULL,
period nvarchar(15) NOT NULL
);

DROP TABLE [dbo].[ErrorLog]
CREATE TABLE [dbo].[ErrorLog]
(
[ErrorLogID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[ErrorTime] [datetime] NULL,
[UserName] [sysname] NOT NULL,
[ErrorNumber] [int] NOT NULL,
[ErrorSeverity] [int] NULL,
[ErrorState] [int] NULL,
[ErrorProcedure] [nvarchar](126) NULL,
[ErrorLine] [int] NULL,
[ErrorMessage] [nvarchar](4000) NOT NULL,
);

DROP TABLE [dbo].[ErrorMsg]
CREATE TABLE [dbo].[ErrorMsg]
(
[ErrorMsgID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[ComputerSN] [nvarchar](45) NOT NULL,
[ErrorMsg] [nvarchar](250) NOT NULL, 
);

SELECT * FROM ErrorLog
SELECT * FROM ErrorMsg 
 --SELECT firstName,lastName,surname,identityNumber,DOB,gender,cellNumber,email,address1,address2,picture,accNumber,accType,accState,dateOpened,expires
	--	 FROM Customer.Customers, Customer.Account, Customer.Contact, Customer.Images 
	--	 WHERE CustomerID = (SELECT CustIDAcc FROM Customer.Account WHERE accNumber = '1000000000') AND CustIDAcc = '2000000000'  AND CustIDConact = '2000000000' AND CustIDImages = '2000000000' 
