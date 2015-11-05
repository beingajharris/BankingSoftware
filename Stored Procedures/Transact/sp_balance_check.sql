USE [Banking System] 
GO

--ALTER PROCEDURE sp_balance_check
CREATE PROCEDURE sp_balance_check
@AccountNumber int,
@PiCode int

AS 
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

		IF EXISTS (SELECT pin FROM Customer.Account WHERE accNumber = @AccountNumber AND pin = @PiCode)

		SELECT available, balance FROM Customer.Account WHERE accNumber = @AccountNumber AND pin = @PiCode

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
