USE [Banking System] 
GO

ALTER PROCEDURE sp_withdraw
--CREATE PROCEDURE sp_withdraw
@AccountNumber int,
@Amount money,
@PostingDate datetime,
@TransDescription varchar(50),
@ComputerSN nvarchar(25),
@PinCode int,
@TransDate date,
@Available money,
@Balance money,
@Total money

AS
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

		--SET @AccType = (SELECT accType FROM Customer.Account WHERE accNumber = @AccountNumber)
		SET @Total = @Amount + (SELECT amount FROM [Account].[Fees]  WHERE fee = 'Withdrawal')

		IF EXISTS (SELECT pin FROM Customer.Account WHERE accNumber = @AccountNumber AND pin = @PinCode)

		BEGIN

		IF EXISTS (SELECT available FROM Customer.Account WHERE accNumber = @AccountNumber AND available > @Total)

		BEGIN

		IF EXISTS (SELECT amount FROM [Account].[DailyLimit] WHERE accNmbDaily = @AccountNumber AND amount > @Amount)

		BEGIN

		UPDATE Customer.Account SET available = available - @Amount, balance = balance - @Amount 
		WHERE accNumber = @AccountNumber AND pin = @PinCode 

		UPDATE Customer.Account SET available = available - (SELECT amount FROM [Account].[Fees]  WHERE fee = 'Withdrawal')
		WHERE accNumber = @AccountNumber

		SET @TransDescription = 'CASH WITHDRAWAL'

		SET @Balance = (SELECT balance FROM Customer.Account WHERE accNumber = @AccountNumber)
		SET @Available = (SELECT available FROM Customer.Account WHERE accNumber = @AccountNumber)

		INSERT INTO Customer.Transactions(accNmbTrans,postingDate,transDate,tranDescription,fundsIn,fundsOut,available,balance)
		VALUES(@AccountNumber,@PostingDate,@TransDate,@TransDescription,' ',@Amount,@Available ,@Balance)

		SELECT transDate FROM Customer.Transactions WHERE accNmbTrans = @AccountNumber

		END

		ELSE

		INSERT INTO [dbo].[ErrorMsg] (ComputerSN,ErrorMsg)VALUES(@ComputerSN,'You have exceeded your daily limit, please contact the nearest brach to change your daily limit.')

		END

		ELSE

		INSERT INTO [dbo].[ErrorMsg] (ComputerSN,ErrorMsg)VALUES(@ComputerSN,'Transaction was canceled, due to insuficient funds')

		END

		ELSE

		INSERT INTO [dbo].[ErrorMsg] (ComputerSN,ErrorMsg)VALUES(@ComputerSN,'Incorrect pin entered')

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