USE [Banking System] 
GO

--ALTER PROCEDURE sp_update_daily_limit
CREATE PROCEDURE sp_update_daily_limit

@AccountNumber	int,
@Amount			money,
@Period			nvarchar(10),
@From			date,
@Selected		varchar(10),
@To				numeric

AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		UPDATE Account.DailyLimit SET TempAmount = @Amount, period = @Period, [From] = @From, [To] = @From 
		WHERE accNmbDaily = @AccountNumber 

		IF @Selected = 'Days'

		BEGIN

		UPDATE Account.DailyLimit SET [TO] = (SELECT DATEADD(DAY,@To,[TO]) FROM Account.DailyLimit WHERE accNmbDaily = @AccountNumber)
		WHERE accNmbDaily = @AccountNumber
		
		SELECT [From], [To]
		FROM Account.DailyLimit
		WHERE accNmbDaily = @AccountNumber AND [From] = @From 
		 
		END

		IF @Selected = 'Weeks'

		BEGIN

		UPDATE Account.DailyLimit SET [TO] = (SELECT DATEADD(WEEK,@To,[TO]) FROM Account.DailyLimit WHERE accNmbDaily = @AccountNumber)
		WHERE accNmbDaily = @AccountNumber
		
		SELECT [From], [To]
		FROM Account.DailyLimit
		WHERE accNmbDaily = @AccountNumber AND [From]  = @From 
		 
		 END

		IF @Selected = 'Months'


		BEGIN

		UPDATE Account.DailyLimit SET [TO] = (SELECT DATEADD(MONTH, @To,[TO]) FROM Account.DailyLimit WHERE accNmbDaily = @AccountNumber)
		WHERE accNmbDaily = @AccountNumber
		
		SELECT [From], [To]
		FROM Account.DailyLimit
		WHERE accNmbDaily = @AccountNumber AND [From]  = @From 
		 
		END

		IF @Selected = 'Forever'

		BEGIN

		UPDATE Account.DailyLimit SET amount = @Amount, TempAmount = NULL, period = @Period, [From] = NULL, [To] = NULL
		WHERE accNmbDaily = @AccountNumber 

		SELECT [From], [To]
		FROM Account.DailyLimit
		WHERE accNmbDaily = @AccountNumber

		END

		--UPDATE Account.DailyLimit SET [TO] = (SELECT DATEADD(DAY, 1,[TO]) FROM Account.DailyLimit WHERE accNmbDaily = '1000000002')
		--WHERE accNmbDaily = '1000000002'

		--SELECT OrderDate, DATEADD(year,1,OrderDate) AS OneMoreYear,
		--DATEADD(month,1,OrderDate) AS OneMoreMonth,
		--DATEADD(day,-1,OrderDate) AS OneLessDay
		--FROM Sales.SalesOrderHeader
		--WHERE SalesOrderID in (43659,43714,60621);

	COMMIT TRANSACTION;
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT >0
			BEGIN
				ROLLBACK TRANSACTION;
			END
			EXECUTE uspLogError 
		END CATCH
END;