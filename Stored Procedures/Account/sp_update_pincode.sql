USE [Banking System] 
GO

--ALTER PROCEDURE sp_update_pincode
CREATE PROCEDURE sp_update_pincode

@AccountNumber int,
@PinEntered int,
@NewPin int

AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		SELECT pin
		FROM Customer.Account 
		WHERE accNumber = @AccountNumber AND pin = @PinEntered 

		IF @PinEntered = (SELECT pin FROM Customer.Account WHERE accNumber = @AccountNumber)
		 
		 UPDATE Customer.Account SET pin = @NewPin, pinAtempt = 3
		 WHERE accNumber = @AccountNumber

		 ELSE

		 UPDATE Customer.Account SET pinAtempt=pinAtempt-1
		 WHERE accNumber = @AccountNumber 

		
		COMMIT TRANSACTION;
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT >0
			BEGIN
				ROLLBACK TRANSACTION;
			END

			--EXECUTE sp_error 
		END CATCH
END