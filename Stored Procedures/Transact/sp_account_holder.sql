USE [Banking System] 
GO

--ALTER PROCEDURE sp_account_holder
CREATE PROCEDURE sp_account_holder
@AccountNumber int

AS 
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

		SELECT accountHolder FROM Customer.Customers WHERE CustomerID = (SELECT CustIDAcc FROM Customer.Account WHERE accNumber = @AccountNumber)
		

COMMIT TRANSACTION
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION
			END
		END CATCH
END;