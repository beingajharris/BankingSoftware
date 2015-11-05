USE [Banking System] 
GO

ALTER PROCEDURE sp_transfer
--CREATE PROCEDURE sp_transfer
@AccountNumber varchar(10),
@AccTransfer varchar(10),
@PostingDate datetime,
@TransDescription varchar(50),
@TransDescription1 varchar(50),
@PinCode int,
@ComputerSN nvarchar(25),
@AccHolder varchar(15),
@CheckAccHlder varchar(15),
@Available money,
@Balance money,
@Available1 money,
@Balance1 money,
@Amount money,
@TransDate date,
@Total money

AS 
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		--ADDING THE AMOUNT ENTERED WITH THE TRANSFER FEE
		
		SET @Total = @Amount + (SELECT amount FROM [Account].[Fees]  WHERE fee = 'Transfer')

		--GETTING THE CUSTOMER_ID FROM THE CUSTOMER TABLE

		SET @CheckAccHlder =  (SELECT CustIDAcc FROM Customer.Account WHERE accNumber = @AccTransfer)

		--CHECKING THE NAME OF THE ACCOUNT HOLDER ENTERED IS CORRECT

		IF EXISTS (SELECT accountHolder FROM Customer.Customers WHERE CustomerID = @CheckAccHlder AND accountHolder LIKE @AccHolder )

		BEGIN

		--CHECKING IF THE REQUIRED AMOUNT IS AVAILABLE TO PROCEED WITH THE TRANSFER

		IF EXISTS (SELECT available FROM Customer.Account WHERE accNumber = @AccountNumber AND available > @Total )

		BEGIN
		
		--TAKING OUT MONEY FROM THE ACCOUT THAT IS DOING THE TRANSFER

		UPDATE Customer.Account SET available = available - @Amount, balance = balance - @Amount 
		WHERE accNumber = @AccountNumber AND pin = @PinCode

		--MINUSING THE TRANFER FEE

		UPDATE Customer.Account SET available = available - (SELECT amount FROM [Account].[Fees]  WHERE fee = 'Transfer')
		WHERE accNumber = @AccountNumber AND pin = @PinCode

		--BEGIN

		--POSTING A TRANFER TRANSACTION IN THE ACCOUNT THAT IS MAKING THE TRANSFER

		SET @TransDescription = 'PAYMENT TO ' + @AccTransfer 
		SET @Balance = (SELECT balance FROM Customer.Account WHERE accNumber = @AccountNumber)
		SET @Available = (SELECT available FROM Customer.Account WHERE accNumber = @AccountNumber)

		INSERT INTO Customer.Transactions(accNmbTrans,postingDate,transDate,tranDescription,fundsIn,fundsOut,available,balance)
		VALUES(@AccountNumber,@PostingDate,@TransDate,@TransDescription,' ',@Amount,@Available,@Balance)

		--ADDING

		--TAKING MONEY IN THE ACCOUNT THAT IS RECEIVING MONEY

		UPDATE Customer.Account SET available = available + @Amount, balance = balance + @Amount 
		WHERE accNumber = @AccTransfer

		--MINUSING THE MONEY IN FEE

		UPDATE Customer.Account SET available = available - (SELECT amount FROM [Account].[Fees] WHERE fee = 'Deposite')
		WHERE accNumber = @AccTransfer

		--POSTING A TRANSACTION IN THE ACCOUNT THAT IS RECEIVING THE MONEY

		SET @TransDescription1 = 'PAYMENT FROM ' + @AccountNumber
		SET @Balance1 = (SELECT balance FROM Customer.Account WHERE accNumber = @AccTransfer)
		SET @Available1 = (SELECT available FROM Customer.Account WHERE accNumber = @AccTransfer)

		INSERT INTO Customer.Transactions(accNmbTrans,postingDate,transDate,tranDescription,fundsIn,fundsOut,available,balance)
		VALUES(@AccTransfer,@PostingDate,@TransDate,@TransDescription1,@Amount,' ',@Available1,@Balance1)

		SELECT available FROM Customer.Account WHERE accNumber = @AccountNumber AND pin = @PinCode

		END
		  
		ELSE
		  
		INSERT INTO [dbo].[ErrorMsg] (ComputerSN,ErrorMsg)VALUES(@ComputerSN,'Transaction was canceled, due to incorrect pin entered.') 

		END

		ELSE
		 
		INSERT INTO [dbo].[ErrorMsg] (ComputerSN,ErrorMsg)VALUES(@ComputerSN,'Transaction was canceled, due to insuficient funds.') 

		

		
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