Use Company
GO
CREATE PROCEDURE usp_UpdateDepartmentManager(
	@DNumber INT,
	@MgrSSN NUMERIC(9,0)
)
AS
BEGIN
	IF(SELECT COUNT(DNumber) FROM dbo.Department WHERE MgrSSN = @MgrSSN) = 0
	BEGIN
		UPDATE [dbo].[Department]
		SET 
			MgrSSN = @MgrSSN, 
			MgrStartDate = GETDATE()
		WHERE
			DNumber = @DNumber

		UPDATE [dbo].[Employee]
		SET
			SuperSSN = @MgrSSN
		WHERE
			SSN !=  @MgrSSN
			AND Dno = @DNumber
			
	END
	  ELSE RAISERROR('Could not give the MgrSSN the new values', 16, 1);
END
