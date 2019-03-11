USE Company;

GO
CREATE FUNCTION udf_GetEmployeeCount(@DNumber INT)
	RETURNS INT
	AS BEGIN
		DECLARE @EmpCount INT;

		SELECT @EmpCount = COUNT(*) 
		FROM Employee 
		WHERE Dno = @Dnumber
		GROUP BY Dno;

		RETURN(@EmpCount)
	END
GO
ALTER TABLE
	Department
	ADD EmpCount AS (dbo.udf_GetEmployeeCount([DNumber]))

GO

ALTER PROCEDURE [dbo].[usp_GetAllDepartments] 
	AS BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Department;
	
END

GO
ALTER PROCEDURE [dbo].[usp_GetDepartment]
	@DNumber varchar(50)
	AS BEGIN

	SET NOCOUNT ON;

	IF(NOT EXISTS (SELECT * FROM Department 
				WHERE DNumber = @DNumber))
		BEGIN
			RAISERROR('Department does not exists', 16, 1);
		END
		
		SELECT * FROM Department WHERE DNumber = @DNumber
		
END

