USE [Banking System] 
GO

--ALTER PROCEDURE sp_retriv_withdraw
CREATE PROCEDURE sp_retriv_withdraw
@AccountNumber int,
@CustID int

AS 
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

		SET @CustID = (SELECT CustIDAcc FROM Customer.Account WHERE accNumber = @AccountNumber)

		SELECT firstName,lastName,surname,available,picture
		FROM Customer.Customers,Customer.Account,Customer.Images 
		WHERE CustomerID = @CustID AND accNumber = @AccountNumber AND CustIDImages = @CustID

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
