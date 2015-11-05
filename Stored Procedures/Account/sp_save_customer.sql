USE [Banking System] 
GO

--ALTER PROCEDURE sp_save_customer
CREATE PROCEDURE sp_save_customer
@FirstName		varchar(15),
@LastName		varchar(15),
@Surname		varchar(15),
@Initials		varchar(10),
@Title			varchar(5),
@AccountHolder	varchar(30),
@BOD			date,
@IdentityNumber nvarchar(13),
@gender			varchar(6),
---Images
@Picture		image,
@IdCopy			image,
@Residence		image,
@ConsernForm	image,
@SuretyIDcopy	image,
--[Account]
@AccountNumber	int,
@AccNumber		int,
@AccountType	varchar(15),
@Pin			int,
@PinAtempt		int,
@Available		money,
@Balance		money,
@AccState		varchar(10),
@DateOpened		date,
@Expires		date,
--[Contact]
@CellNumber		nvarchar(10),
@Email			nvarchar(25),
@Address1		nvarchar(40),
@Address2		nvarchar(40),
--[AccountTnC]
@Accepted		bit,
--[Daily Limit]
@AccNmbDaily	int,
@Amount			money

--[MobileBanking]
--[MobileBankingTnC]
--[RemoteBanking]
--[RemoteBankingTnC]

AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		IF EXISTS (SELECT identityNumber FROM Customer.Customers WHERE identityNumber = @IdentityNumber) 

		BEGIN

		UPDATE Customer.Customers SET firstName = @FirstName , lastName = @LastName , surname = @Surname ,DOB = @BOD , gender = @gender 
		WHERE identityNumber = @IdentityNumber

		SET @Title = (SELECT
		CASE gender
		WHEN 'MALE' THEN 'Mr'
		WHEN 'FEMALE' THEN 'Ms'
		ELSE NULL END 
		FROM Customer.Customers WHERE identityNumber = @IdentityNumber) 

		SET @Initials = (SELECT
		 SUBSTRING(firstName,1,1) +
		 SUBSTRING(lastName,1,1) 
		 FROM Customer.Customers WHERE identityNumber = @IdentityNumber)

		SET @AccountHolder = @Title  + ' ' + @Initials + ' ' + @Surname 

		UPDATE Customer.Customers SET initials = @Initials , title = @Title , accountHolder = @AccountHolder
		WHERE identityNumber = @IdentityNumber

		UPDATE Customer.Contact SET cellNumber = @CellNumber , email = @Email , address1 = @Address1 , address2 = @Address2 
		WHERE CustIDConact  = (SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber)

		UPDATE Customer.Images SET idCopy = @IdCopy , picture = @Picture , Residence = @Residence , ConsernForm = @ConsernForm, SuretyIDcopy = @SuretyIDcopy, DateModified = @DateOpened
		WHERE CustIDImages = (SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber)
		
		INSERT INTO Customer.Account(CustIDAcc ,accState,accType,available,balance,dateOpened,expires,pin,pinAtempt)
		VALUES
		((SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber),@AccState,@AccountType,@Available,@Balance,@DateOpened,@Expires,@Pin,@PinAtempt);

		INSERT INTO Customer.AccountTnC(CustIDAccTnC,Accepted,[Signature],ThumbPrint)
		VALUES
		((SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber),@Accepted,NULL,NULL);

		SET @AccountNumber = (SELECT accNumber FROM Customer.Account WHERE CustIDAcc = (SELECT CustomerID FROM Customer.Customers WHERE identityNumber =@IdentityNumber) AND dateOpened =@DateOpened)

		INSERT INTO Account.DailyLimit(accNmbDaily,amount,TempAmount, period,[From],[To])
		VALUES
		(@AccountNumber,@Amount,NULL,'Forever',NULL,NULL);

		UPDATE Customer.Account SET expires =(SELECT DATEADD(YEAR,5,expires) FROM Customer.Account WHERE accNumber = @AccountNumber)
		WHERE accNumber = @AccountNumber

		SELECT identityNumber FROM Customer.Customers WHERE identityNumber = @IdentityNumber

		END

		ELSE
		
		BEGIN

		-- CUSTOMER
		INSERT INTO Customer.Customers(firstName,lastName,surname,DOB,identityNumber,gender,initials,title,accountHolder) 
		VALUES 
		(@FirstName,@LastName,@Surname,@BOD,@IdentityNumber,@gender,'BANK','BANK','BANK');


		SET @Title = (SELECT
		CASE gender
		WHEN 'MALE' THEN 'MR'
		WHEN 'FEMALE' THEN 'MS'
		ELSE NULL END 
		FROM Customer.Customers WHERE identityNumber = @IdentityNumber) 

		SET @Initials = (SELECT
		 SUBSTRING(firstName,1,1) +
		 SUBSTRING(lastName,1,1) 
		 FROM Customer.Customers WHERE identityNumber = @IdentityNumber)

		SET @AccountHolder = @Title  + ' ' + @Initials + ' ' + @Surname 

		UPDATE Customer.Customers SET initials = @Initials , title = @Title , accountHolder = @AccountHolder
		WHERE identityNumber = @IdentityNumber



		INSERT INTO Customer.Contact(CustIDConact,cellNumber,email,address1,address2)
		VALUES
		((SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber),@CellNumber,@Email,@Address1,@Address2);

		-- ACCOUNT INFO
		INSERT INTO Customer.Account(CustIDAcc,accState,accType,available,balance,dateOpened,expires,pin,pinAtempt)
		VALUES
		((SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber),@AccState,@AccountType,@Available,@Balance,@DateOpened,@Expires,@Pin,@PinAtempt);
		
		INSERT INTO Customer.AccountTnC(CustIDAccTnC,Accepted,Signature,ThumbPrint)
		VALUES
		((SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber),@Accepted,NULL,NULL);

		 --IMAGE AND DOCUMENTS
		INSERT INTO Customer.Images(CustIDImages,idCopy,picture,Residence,ConsernForm,SuretyIDcopy,dateCreated,DateModified)
		VALUES
		((SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber),@IdCopy,@Picture,@Residence,@ConsernForm,@SuretyIDcopy,@DateOpened,@DateOpened)
		
		SET @AccNumber = (SELECT accNumber FROM Customer.Account WHERE CustIDAcc = (SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber) AND dateOpened =@DateOpened)
		
		INSERT INTO Account.DailyLimit(accNmbDaily,amount,TempAmount, period,[From],[To])
		VALUES
		(@AccNumber,@Amount,NULL,'Forever',NULL,NULL);

		UPDATE Customer.Account SET expires =(SELECT DATEADD(YEAR,5,expires) FROM Customer.Account WHERE accNumber = @AccNumber)
		WHERE accNumber = @AccNumber 

		SELECT identityNumber FROM Customer.Customers WHERE identityNumber = @IdentityNumber

		END

		COMMIT TRANSACTION
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT >0
			BEGIN
				ROLLBACK TRANSACTION
			END
			EXECUTE uspLogError 
		END CATCH
END;