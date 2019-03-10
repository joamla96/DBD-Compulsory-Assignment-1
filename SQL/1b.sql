USE Company;
GO
CREATE FUNCTION udf_DepartmentNameExists(@DName VARCHAR(MAX))
	RETURNS BIT
	AS
	BEGIN
		IF EXISTS(SELECT * FROM [dbo].[Department] WHERE DName = @DName)
			RETURN 1;
		ELSE
			RETURN 0;
		
		RETURN 0;
	END

GO

GO
CREATE PROCEDURE usp_UpdateDepartmentName(
	@DNumber INT,
	@DName VARCHAR(50)
)
AS
BEGIN
	IF (dbo.udf_DepartmentNameExists(@DName) = 1)
	BEGIN
			RAISERROR('A Department with name already exists', 16, 1);
	END

	UPDATE [dbo].[Department]
	SET 
		[DName] = @DName
	WHERE
		DNumber = @DNumber
END
