USE [Banking System] 
GO

ALTER PROCEDURE sp_transactions
--CREATE PROCEDURE sp_transactions

@AccountNumber int

AS
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
		--SELECT transType AS Transaction_Type, amount AS Amount, transDate AS Transaction_Date  FROM [Customer].[Transactions] WHERE accNmbTrans = @AccountNumber 
		
		SELECT postingDate AS Posting_Date,transDate AS Transaction_Date,tranDescription As Description,fundsIn As Funds_In,fundsOut AS Funds_Out,available AS Available,balance AS Balance FROM [Customer].[Transactions] WHERE accNmbTrans = @AccountNumber 

		--SELECT accNmbTrans AS Account_Number, accType AS Account_Type, transType AS Transaction_Type, amount AS Amount, transDate AS Transaction_Date  FROM [Customer].[Transactions] WHERE accNmbTrans = @AccountNumber 
		
		COMMIT TRANSACTION
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION
			END
		END CATCH
END;