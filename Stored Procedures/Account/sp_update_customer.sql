USE [Banking System] 
GO

--ALTER PROCEDURE sp_update_customer
CREATE PROCEDURE sp_update_customer
@FirstName		varchar(15),
@LastName		varchar(15),
@Surname		varchar(15),
@BOD			date,
@IdentityNumber nvarchar(13),
@gender			varchar(6),
@CellNumber		nvarchar(10),
@Email			nvarchar(25),
@Address1		nvarchar(40),
@Address2		nvarchar(40),
@Picture		image,
@Residence		image,
@Surety			image,
@ConsernForm	image,
@Today			date

AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

		UPDATE Customer.Customers SET firstName = @firstName ,lastName = @lastName ,surname = @surname ,identityNumber = @identityNumber ,gender = @gender ,DOB = @BOD 
		WHERE identityNumber = @identityNumber 

		UPDATE Customer.Contact SET cellNumber = @cellNumber,email = @email, address1 = @address1, address2 = @address2
		WHERE CustIDConact = (SELECT CustomerID  FROM Customer.Customers WHERE identityNumber = @identityNumber)

		UPDATE Customer.Images SET picture = @Picture, Residence = @Residence, ConsernForm = @ConsernForm, SuretyIDcopy = @Surety, DateModified = @Today
		WHERE CustIDImages =(SELECT CustomerID  FROM Customer.Customers WHERE identityNumber = @identityNumber)

		SELECT picture FROM Customer.Images
		WHERE CustIDImages = (SELECT CustomerID  FROM Customer.Customers WHERE identityNumber = @identityNumber) AND DateModified = @Today

		COMMIT TRANSACTION
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION
			END
		END CATCH
END;