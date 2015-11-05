USE [Banking System] 
GO

--ALTER PROCEDURE sp_cellphone_banking
CREATE PROCEDURE sp_cellphone_banking
@AccountNumber	int,
@EmployeeNumber	int,
@AccessPinCode	int,
@CurentPin		int,
@DateActivated	date,
@DateModified	date,
@Accepted		bit

AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		IF EXISTS(SELECT accNmrMobBank FROM Customer.MobileBanking WHERE accNmrMobBank = @AccountNumber)

		BEGIN
		UPDATE Customer.MobileBanking SET EmpNumber = @EmployeeNumber, AccessPin = @AccessPinCode WHERE accNmrMobBank = @AccountNumber AND AccessPin = @CurentPin

		UPDATE Customer.MobileBankingTnC SET date=@DateModified ,Accepted = @Accepted 

		SELECT AccessPin,accNmrMobBank FROM Customer.MobileBanking WHERE accNmrMobBank = @AccountNumber AND AccessPin = @AccessPinCode

		END

		ELSE
		
		BEGIN

		INSERT INTO Customer.MobileBanking (accNmrMobBank,EmpNumber,AccessPin,dateActivated,dateModified)
		VALUES
		(@AccountNumber,@EmployeeNumber,@AccessPinCode,@DateActivated,@DateModified)

		INSERT INTO Customer.MobileBankingTnC (accNmrMobBank,date,Accepted)
		VALUES
		(@AccountNumber,@DateModified,@Accepted)

		SELECT AccessPin,accNmrMobBank FROM Customer.MobileBanking WHERE accNmrMobBank = @AccountNumber AND AccessPin = @AccessPinCode

		END

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