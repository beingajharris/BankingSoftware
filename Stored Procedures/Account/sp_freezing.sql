USE [Banking System] 
GO

--ALTER PROCEDURE sp_freezing
CREATE PROCEDURE sp_freezing

@AccountNumber	int,
@Reason			nvarchar(200),
@DateFreeze		date
AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		UPDATE Customer.Account SET accState = 'Frozen'
		WHERE accNumber = @AccountNumber

		INSERT INTO Account.Freezing (accNmbState,reason,DateFreeze)
		VALUES
		(@AccountNumber,@Reason,@DateFreeze);

		SELECT accNmbState
		FROM Account.Freezing
		WHERE DateFreeze = @DateFreeze AND accNmbState = @AccountNumber  

		COMMIT TRANSACTION;
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT >0
			BEGIN
				ROLLBACK TRANSACTION;
			END

			--EXECUTE sp_error 
		END CATCH
END;
