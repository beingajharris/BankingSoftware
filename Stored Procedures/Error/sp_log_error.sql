USE [Banking System] 
GO

--ALTER PROCEDURE uspLogError
CREATE PROCEDURE uspLogError

 @ErrorLogID [int] = 0 OUTPUT
 AS
	BEGIN
		SET NOCOUNT ON
		 SET @ErrorLogID = 0;
	BEGIN TRY
		BEGIN TRANSACTION

		 -- Return if there is no error information to log
        IF ERROR_NUMBER() IS NULL
            RETURN;

        -- Return if inside an uncommittable transaction.
        -- Data insertion/modification is not allowed when 
        -- a transaction is in an uncommittable state.
        IF XACT_STATE() = -1
        BEGIN
            PRINT 'Cannot log error since the current transaction is in an uncommittable state. ' 
                + 'Rollback the transaction before executing uspLogError in order to successfully log error information.';
            RETURN;
        END

        INSERT [dbo].[ErrorLog] 
            (
            [UserName], 
            [ErrorNumber], 
            [ErrorSeverity], 
            [ErrorState], 
            [ErrorProcedure], 
            [ErrorLine], 
            [ErrorMessage]
            ) 
        VALUES 
            (
            CONVERT(sysname, CURRENT_USER), 
            ERROR_NUMBER(),
            ERROR_SEVERITY(),
            ERROR_STATE(),
            ERROR_PROCEDURE(),
            ERROR_LINE(),
            ERROR_MESSAGE()
            );

        -- Pass back the ErrorLogID of the row inserted
        SET @ErrorLogID = @@IDENTITY;


		COMMIT TRANSACTION;
	END TRY
		BEGIN CATCH
			PRINT 'An error occurred in stored procedure uspLogError: ';
        EXECUTE sp_print_error
        RETURN -1;
 
		END CATCH
END;