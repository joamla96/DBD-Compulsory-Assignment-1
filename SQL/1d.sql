USE Company;
GO
CREATE PROCEDURE usp_DeleteDepartment
	@DNumber varchar(50)
	AS BEGIN

	SET NOCOUNT ON;

	IF(NOT EXISTS (SELECT * FROM Department 
				WHERE DNumber = @DNumber))
		BEGIN
			RAISERROR('Department does not exists', 16, 1);
		END

		--Removes all Works_on that are connectet to the project in that department
		Delete From Works_on
		Where Pno in (
			SELECT PNumber FROM Project
			WHERE DNum = @DNumber)

		--Removes all project that were in that department
		Delete From Project
		Where DNum = @DNumber

		--Set all emplyee that were in that depatment to have null insted
		--Feel sad form them :(
		UPDATE Employee
		SET Dno = null
		WHERE Dno = @DNumber

		--Removes the linked location of the deleted depatment
		DELETE FROM Dept_Locations
		WHERE DNUmber = @DNumber

		--Delete the department 
		--Now its all gone ...
		DELETE FROM Department
		WHERE DNumber = @DNumber	
	END
