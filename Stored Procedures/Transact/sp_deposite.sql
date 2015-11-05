USE [Banking System] 
GO

ALTER PROCEDURE sp_deposite
--CREATE PROCEDURE sp_deposite
@AccountNumber int,
@PostingDate datetime,
@TransDate datetime,
@TransDescription varchar(50),
@Amount money,
@Available money,
@Balance money

AS 
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

		BEGIN
		UPDATE Customer.Account SET balance = balance + @Amount, available = available + @Amount
		WHERE accNumber = @AccountNumber
		
		UPDATE Customer.Account SET available = available - (SELECT amount FROM [Account].[Fees] WHERE fee = 'Deposite')
		WHERE accNumber = @AccountNumber

		SET @TransDescription = 'CASH DEPOSITE'
		SET @Balance = (SELECT balance FROM Customer.Account WHERE accNumber = @AccountNumber)
		SET @Available = (SELECT available FROM Customer.Account WHERE accNumber = @AccountNumber)

		INSERT INTO Customer.Transactions(accNmbTrans,postingDate,transDate,tranDescription,fundsIn,fundsOut,available,balance)
		VALUES(@AccountNumber,@PostingDate,@TransDate,@TransDescription,@Amount,' ',@Available,@Balance)

		SELECT transDate FROM Customer.Transactions WHERE accNmbTrans = @AccountNumber

		END

		IF EXISTS (SELECT accState FROM Customer.Account WHERE accNumber = @AccountNumber AND accState = 'Inactive')

		BEGIN

		UPDATE Customer.Account SET accState = 'Active' WHERE accNumber = @AccountNumber

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