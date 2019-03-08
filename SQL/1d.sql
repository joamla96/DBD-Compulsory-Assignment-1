USE Company;
GO
CREATE PROCEDURE usp_DeleteDepartment
	@Dname varchar(50),
	@Dnum int OUTPUT
	AS BEGIN

	SET NOCOUNT ON;

	IF(NOT EXISTS (SELECT * FROM Department 
				WHERE DName = @Dname))
		BEGIN
			RAISERROR('Department does not exists', 16, 1);
		END
		
		--Saves the number of the department we want to delete
		SELECT @Dnum = DNumber FROM Department
		WHERE DName = @Dname

		--Removes all Works_on that are connectet to the project in that department
		Delete From Works_on
		Where Pno in (
			SELECT PNumber FROM Project
			WHERE DNum = @Dnum)

		--Removes all project that were in that department
		Delete From Project
		Where DNum = @Dnum

		--Set all emplyee that were in that depatment to have null insted
		--Feel sad form them :(
		UPDATE Employee
		SET Dno = null
		WHERE Dno = @Dnum

		--Removes the linked location of the deleted depatment
		DELETE FROM Dept_Locations
		WHERE DNUmber = @Dnum

		--Delete the department 
		--Now its all gone ...
		DELETE FROM Department
		WHERE DNumber = @Dnum	
	END