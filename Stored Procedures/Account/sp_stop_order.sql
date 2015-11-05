USE [Banking System] 
GO

--ALTER PROCEDURE sp_stop_order
CREATE PROCEDURE sp_stop_order
@AccNumber int,
@AccountNumber int,
@AccHolder nvarchar(20),
@Amount money,
@DateTransaction date,
@DateAdded date,
@Selected nvarchar(25)

AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		IF @Selected = '&Add'

		BEGIN

		IF EXISTS(SELECT * FROM Account.StopOrder WHERE accNmr = @AccNumber AND accNmbStopOrder = @AccountNumber AND amount = @Amount)

		PRINT 'There is already a stop order with the same amount'

		ELSE

		IF EXISTS(SELECT * FROM Customer.Account WHERE accNumber = @AccountNumber)

		INSERT INTO Account.StopOrder (accNmr,accNmbStopOrder,accountHolder,amount,transactionDate,dateAdded)
		VALUES(@AccNumber,@AccountNumber,@AccHolder,@Amount,@DateTransaction,@DateAdded);

		SELECT * FROM Account.StopOrder
		WHERE accNmr = @AccNumber AND accNmbStopOrder = @AccountNumber AND amount = @Amount

		END

		IF @Selected = '&Remove'

		BEGIN

		DELETE FROM Account.StopOrder
		WHERE accNmr = @AccNumber AND accNmbStopOrder = @AccountNumber AND amount = @Amount

		SELECT * FROM Account.StopOrder 
		WHERE accNmr = @AccNumber AND accNmbStopOrder = @AccountNumber AND amount = @Amount

		END

		--IF @Selected = '&Reverse transaction'

		--BEGIN

		--UPDATE 

		--END


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